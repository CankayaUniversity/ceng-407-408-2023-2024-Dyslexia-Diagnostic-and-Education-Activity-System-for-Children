using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DyslexiaApp.API.Services
{
    public class DyslexiaDiagnosisService
    {
        private readonly AppDbContext _context;

        // Constructor düzgün bir şekilde tanımlanmalıdır.
        public DyslexiaDiagnosisService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<DyslexiaDiagnosisDto[]> GetDyslexiaDiagnosesAsync() =>
        await _context.DyslexiaDiagnosis
        .AsNoTracking()
        .Select(diagnosis => new DyslexiaDiagnosisDto(
            diagnosis.Id,
            diagnosis.TestResults,
            diagnosis.FeedBack,
            diagnosis.Description,
            // MatchingGames için DTO'ları oluşturma
            diagnosis.MatchingGames.Select(matchingGame => new MatchingGameDto(
                matchingGame.Id,
                null,
                // DyslexiaDiagnosisDto burada null geçilir, döngüsel referansı önlemek için
                new EducationalDto(
                    matchingGame.EducationalGame.Id,
                    matchingGame.EducationalGame.Name,
                    matchingGame.EducationalGame.Description,
                    matchingGame.EducationalGame.GameSessions.Select(gs => new GameSessionDto(gs.Id, gs.SessionScore)).ToArray(),
                    Array.Empty<MatchingGameDto>() // Eğitim oyununun eşleşen oyunları için boş bir dizi
                ),
                matchingGame.GameSessions.Select(gs => new GameSessionDto(gs.Id, gs.SessionScore)).ToArray()
            )).ToArray(),
            // NavigationGames için DTO'ları oluşturma
            diagnosis.NavigationGames.Select(navGame => new NavigationGameDto(
                navGame.Id,
                null
                 // Burada da DyslexiaDiagnosisDto için null geçiyoruz, döngüsel referansı önlemek için
            )).ToArray()
        ))
        .ToArrayAsync();

        public async Task<DyslexiaDiagnosisDto> AddDyslexiaDiagnosisAsync(DyslexiaDiagnosisDto newDiagnosisDto)
        {
            var newDiagnosis = new DyslexiaDiagnosis
            {
                Id = Guid.NewGuid(),
                TestResults = newDiagnosisDto.TestResults,
                FeedBack = newDiagnosisDto.FeedBack,
                Description = newDiagnosisDto.Description,
                // MatchingGames ve NavigationGames gibi ilişkili varlıklar burada yönetilmeli
            };

            _context.DyslexiaDiagnosis.Add(newDiagnosis);
            await _context.SaveChangesAsync();

            return newDiagnosisDto; // Gerçek uygulamada, oluşturulan varlıkla doldurulmuş yeni bir DTO döndürmek daha uygun olabilir.
        }


    }
}