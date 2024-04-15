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
                            matchingGame.EducationalGame.GameSessions.Select(gs => new GameSessionDto(gs.Id, gs.SessionScore)).ToArray()
                        // MatchingGames için argüman geçirilmiyor.
                        ),
                        matchingGame.GameSessions.Select(gs => new GameSessionDto(gs.Id, gs.SessionScore)).ToArray()
                    )).ToArray(),
                    diagnosis.NavigationGames.Select(navGame => new NavigationGameDto(
                        navGame.Id
                    // DyslexiaDiagnosis için argüman geçirilmiyor.
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

        public async Task CreateUserAndDiagnosisAsync()
        {
            var newUser = new User
            {
                // Kullanıcı detayları, Id otomatik olarak atanacaktır.
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync(); // Bu noktada newUser.Id otomatik olarak doldurulur.

            var newDiagnosis = new DyslexiaDiagnosis
            {
                Id = newUser.Id, // newUser.Id burada kullanılıyor.
                                     // Diğer teşhis detayları...
            };

            _context.DyslexiaDiagnosis.Add(newDiagnosis);
            await _context.SaveChangesAsync();
        }
    }
}
