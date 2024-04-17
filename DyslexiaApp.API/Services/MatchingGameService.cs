using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace DyslexiaApp.API.Services
{
    public class MatchingGameService
    {
        private readonly AppDbContext _context;

        public MatchingGameService(AppDbContext context, EducationalGameService educationalGameService)
        {
            _context = context;
        }
        public async Task<bool> StartGameAsync(Guid userId, Guid gameId)
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

            var questions = GenerateQuestions(game.EducationalGame);


            _context.GameSessions.Add(session);
            await _context.SaveChangesAsync();

            return true;
        }

        private List<Question> GenerateQuestions(EducationalGame game)
        {
            var questions = new List<Question>();

            for(int i = 0; i < 10; i++)
            {
                var question = new Question
                {
                    QuestionText = $"Question {i + 1} : {game.Description.Substring(0, Math.Min(50, game.Description.Length))}...",
                    Options = new List<string>
                    {
                        "Options A",
                        "Options B",
                        "Options C",
                        "Options D"
                    },
                    CorrectAnswerIndex = new Random().Next(0, 4)
                };
                questions.Add(question);
            }
            return questions;

        }

        public int EvaluateAnswers(List<Question> questions, List<int> userAnswers)
        {
            int score = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].CorrectAnswerIndex == userAnswers[i])
                {
                    score++;
                }
            }
            return score;
        }

        public async Task UpdateSessionScoreAsync(Guid sessionId, int score)
        {
            var session = await _context.GameSessions.FindAsync(sessionId);
            
            if (session == null)
            {
                session.SessionScore = score;

                await _context.SaveChangesAsync();
            }
        }
        
        public class Question
        {
            public string QuestionText { get; set; }
            public List<string> Options { get; set; }
            public int CorrectAnswerIndex { get; set; }
        }
    }
}
