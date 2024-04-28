using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DyslexiaApp.API.Services
{
    public class MatchingGameService
    {
        private readonly AppDbContext _context;

        public MatchingGameService(AppDbContext context)
        {
            _context = context;
        }

        // Oyun başlatma
        public async Task<bool> StartGameAsync(Guid userId, Guid gameId)
        {
            try
            {
                var game = await _context.MatchingGames
                                     .Include(mg => mg.EducationalGame)
                                     .FirstOrDefaultAsync(mg => mg.Id == gameId);

                if (game == null)
                {
                    return false;
                }

                var user = await _context.Users.FindAsync(userId);
                if (user == null) return false;

                var session = new GameSession
                {
                    Id = Guid.NewGuid(),
                    EducationalGame = game.EducationalGame,
                    User = user,
                    SessionScore = 0
                };

                _context.GameSessions.Add(session);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }

        // Soru ve resimleri oluşturma
        public async Task CreateQuestionWithImages(Guid mainImageId, List<Guid> optionImageIds, int correctIndex)
        {
            Image mainImage = await _context.Images.FindAsync(mainImageId);
            List<Image> optionImages = await _context.Images.Where(img => optionImageIds.Contains(img.Id)).ToListAsync();

            Question question = new Question
            {
                Id = Guid.NewGuid(),
                QuestionText = "Find the symmetric image",
                MainImage = mainImage,
                ImageOptions = optionImages,
                CorrectAnswerIndex = correctIndex
            };

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
        }

        // Soruları bir oyunla ilişkilendirme
        public async Task AddQuestionToMatchingGame(Guid gameId, Guid questionId)
        {
            MatchingGame game = await _context.MatchingGames.Include(g => g.Questions).FirstOrDefaultAsync(g => g.Id == gameId);
            Question question = await _context.Questions.FindAsync(questionId);

            if (game != null && question != null)
            {
                game.Questions.Add(question);
                await _context.SaveChangesAsync();
            }
        }

        // Oyun için soruları yükleme
        public async Task<List<Question>> LoadQuestionsForGame(Guid gameId)
        {
            // MatchingGame içindeki Questions koleksiyonunu ve her Question için MainImage ve ImageOptions'ı yükleyin.
            MatchingGame game = await _context.MatchingGames
                 .Include(g => g.Questions)
                    .ThenInclude(q => q.MainImage)  // MainImage doğru yüklendi
                .Include(g => g.Questions)
                    .ThenInclude(q => q.ImageOptions)  // ImageOptions her bir Question için yüklenmeli
                .FirstOrDefaultAsync(g => g.Id == gameId);

            return game?.Questions.ToList();
        }

    }
}
