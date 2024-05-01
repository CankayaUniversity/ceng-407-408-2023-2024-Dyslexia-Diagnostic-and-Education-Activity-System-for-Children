using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DyslexiaApp.API.Services
{
    public class NavigationGameService
    {
        private readonly AppDbContext _context;
        private Random _random = new Random();

        public NavigationGameService(AppDbContext context)
        {
            _context = context;
        }

        // Oyun başlatma
        public async Task<NavigationGameDto> StartGameAsync(Guid diagnosisId)
        {
            var diagnosis = await _context.DyslexiaDiagnosis
                .Include(d => d.NavigationGames)
                .FirstOrDefaultAsync(d => d.Id == diagnosisId);

            if (diagnosis == null)
            {
                throw new Exception("Diagnosis not found.");
            }

            // Balonun konumunu rastgele belirle
            string balloonPosition = _random.Next(2) == 0 ? "Left" : "Right";

            var game = new NavigationGame
            {
                Id = Guid.NewGuid(),
                DyslexiaDiagnosis = diagnosis,
                BalloonPosition = balloonPosition
            };

            _context.NavigationGames.Add(game);
            await _context.SaveChangesAsync();

            return new NavigationGameDto(game.Id, new List<QuestionDto>());
        }


        // Kullanıcının seçimini kontrol etme
        public async Task<bool> CheckChoiceAsync(Guid gameId, string choice)
        {
            var game = await _context.NavigationGames.FindAsync(gameId);
            if (game == null) return false;

            // Kullanıcının seçimi, kaydedilmiş konum ile karşılaştır
            bool isCorrect = game.BalloonPosition == choice;

            return isCorrect;
        }


        // Oyun için soruları yükleme
        public async Task<List<QuestionDto>> LoadQuestionsForGame(Guid gameId)
        {
            var game = await _context.NavigationGames
                .Include(g => g.Questions)
                    .ThenInclude(q => q.MainImage)
                .FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
            {
                throw new Exception("Game not found.");
            }

            return game.Questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                MainImage = q.MainImage != null ? new ImageDto { Id = q.MainImage.Id, Url = q.MainImage.Url, Description = q.MainImage.Description } : null,
                ImageOptions = q.ImageOptions.Select(io => new ImageDto { Id = io.Id, Url = io.Url, Description = io.Description }).ToList(),
                CorrectAnswerIndex = q.CorrectAnswerIndex
            }).ToList();
        }
    }
}
