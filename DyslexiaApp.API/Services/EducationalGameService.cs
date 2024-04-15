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
                .Select(game => new EducationalDto(
                    game.Id,
                    game.Name,
                    game.Description,
                    game.GameSessions.Select(gs => new GameSessionDto(
                        gs.Id,
                        gs.SessionScore
                    )).ToArray()
                // MatchingGames alanı kaldırıldığı için, burada sadece dört argüman var.
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
