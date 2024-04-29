using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DyslexiaApp.API.Services
{
    public class DyslexiaDiagnosisService
    {
        private readonly AppDbContext _context;

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
            diagnosis.MatchingGames.Select(matchingGame => new MatchingGameDto(
                matchingGame.Id,
                new EducationalDto(
                    matchingGame.EducationalGame.Id,
                    matchingGame.EducationalGame.Name,
                    matchingGame.EducationalGame.Description,
                    matchingGame.EducationalGame.GameSessions.Select(gs => new GameSessionDto(gs.Id, gs.SessionScore)).ToArray(),
                    new List<MatchingGameDto>() // Bu liste ilişkili oyunlar için, gerekirse doldur
                ),
                matchingGame.GameSessions.Select(gs => new GameSessionDto(gs.Id, gs.SessionScore)).ToArray(),
                new List<QuestionDto>() // Eksik olan sorular listesi
            )).ToArray(),
            diagnosis.NavigationGames.Select(navGame => new NavigationGameDto(
                navGame.Id
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
                // MatchingGames ve NavigationGames gibi ilişkili varlıklar yönetilmeli,
                // bu örnekte basitleştirilmiştir.
            };

            _context.DyslexiaDiagnosis.Add(newDiagnosis);
            await _context.SaveChangesAsync();

            return newDiagnosisDto; // Ideal olarak, oluşturulan varlık ile doldurulmuş yeni bir DTO döndürülmelidir.
        }

        
    }
}
