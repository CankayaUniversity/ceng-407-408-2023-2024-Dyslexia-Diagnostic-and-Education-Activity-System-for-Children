namespace DyslexiaAppMAUI.Shared.Dtos;

public record struct MatchingGameDto(
    Guid Id,
    // DyslexiaDiagnosisDto? DyslexiaDiagnosis, // Kaldırıldı
    EducationalDto EducationalGame,
    GameSessionDto[] GameSessions,
    List <QuestionDto> Questions
);
