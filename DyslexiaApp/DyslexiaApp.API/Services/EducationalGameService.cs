using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DyslexiaApp.API.Services
{
    public class EducationalGameService
    {
        private readonly AppDbContext _context;

        // Constructor düzgün bir şekilde tanımlanmalıdır.
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
            // GameSessions için DTO'ları oluşturma
            game.GameSessions.Select(gs => new GameSessionDto(
                gs.Id,
                gs.SessionScore
            )).ToArray(),
            // MatchingGames için DTO'ları oluşturma
            game.MatchingGames.Select(mg => new MatchingGameDto(
                mg.Id,
                null,
                 // DyslexiaDiagnosisDto burada null, çünkü döngüsel referansı önlemek istiyoruz
                      // Bu noktada EducationalGame bilgisini tekrar include etmemize gerek yok, zaten onu işliyoruz
                      // Ancak, yapıyı tutarlı kılmak adına, yalnızca id ve temel bilgileri döndürebiliriz
                new EducationalDto(
                    mg.EducationalGame.Id,
                    mg.EducationalGame.Name,
                    mg.EducationalGame.Description,
                    Array.Empty<GameSessionDto>(), // Burada GameSessions'ı dahil etmeyeceğiz, çünkü zaten üst düzeyde işliyoruz
                    Array.Empty<MatchingGameDto>() // Aynı şekilde, burada da MatchingGames'ı dahil etmiyoruz
                ),
                mg.GameSessions.Select(gs => new GameSessionDto(
                    gs.Id,
                    gs.SessionScore
                )).ToArray()
            )).ToArray()
        ))
        .ToArrayAsync();

        public async Task<EducationalDto> AddEducationalGameAsync(EducationalDto newGameDto)
        {
            var newGame = new EducationalGame
            {
                Id = Guid.NewGuid(),
                Name = newGameDto.Name,
                Description = newGameDto.Description,
                // GameSessions ve MatchingGames gibi ilişkili varlıklar burada yönetilmeli
            };

            _context.EducationalGames.Add(newGame);
            await _context.SaveChangesAsync();

            return newGameDto; // Gerçek uygulamada, oluşturulan varlıkla doldurulmuş yeni bir DTO döndürmek daha uygun olabilir.
        }


    }
}