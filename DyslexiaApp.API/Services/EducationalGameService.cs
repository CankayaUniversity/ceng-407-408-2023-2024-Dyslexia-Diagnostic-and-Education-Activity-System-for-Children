using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DyslexiaApp.API.Services
{
    public class EducationalGameService
    {
        private readonly AppDbContext _context;

        public EducationalGameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<EducationalDto[]> GetEducationalGamesAsync() =>
    await _context.EducationalGames
    .AsNoTracking()
    .Include(game => game.MatchingGames)
        .ThenInclude(mg => mg.Questions)
            .ThenInclude(q => q.MainImage)
    .Include(game => game.MatchingGames)
        .ThenInclude(mg => mg.Questions)
            .ThenInclude(q => q.ImageOptions)
    .Select(game => new EducationalDto(
        game.Id,
        game.Name,
        game.Description,
        game.GameSessions.Select(gs => new GameSessionDto(gs.Id, gs.SessionScore)).ToArray(),
        game.MatchingGames.Select(mg => new MatchingGameDto(
            mg.Id,
            new EducationalDto(
                mg.EducationalGame.Id,
                mg.EducationalGame.Name,
                mg.EducationalGame.Description,
                new GameSessionDto[0],
                new List<MatchingGameDto>()),
            mg.GameSessions.Select(gs => new GameSessionDto(gs.Id, gs.SessionScore)).ToArray(),
            mg.Questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                MainImage = q.MainImage != null ? new ImageDto { Id = q.MainImage.Id, Url = q.MainImage.Url, Description = q.MainImage.Description } : null,
                ImageOptions = q.ImageOptions.Select(io => new ImageDto { Id = io.Id, Url = io.Url, Description = io.Description }).ToList(),
                CorrectAnswerIndex = q.CorrectAnswerIndex
            }).ToList()
        )).ToList()
    ))
    .ToArrayAsync();






        public async Task<EducationalDto> AddEducationalGameAsync(EducationalDto newGameDto)
        {
            var newGame = new EducationalGame
            {
                Id = Guid.NewGuid(),
                Name = newGameDto.Name,
                Description = newGameDto.Description,
                // GameSessions ve MatchingGames gibi ilişkili varlıklar yönetilmeli,
                // bu örnekte basitleştirilmiştir.
            };

            _context.EducationalGames.Add(newGame);
            await _context.SaveChangesAsync();

            return newGameDto; // Ideal olarak, oluşturulan varlık ile doldurulmuş yeni bir DTO döndürülmelidir.
        }

        

    }
}
