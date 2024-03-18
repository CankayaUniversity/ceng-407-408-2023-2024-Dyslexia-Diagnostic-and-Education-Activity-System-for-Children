namespace DyslexiaAppMAUI.Shared.Dtos;

public record struct MatchingGameDto(
    Guid Id,
    TimeSpan TimeSpent,
    DyslexiaDiagnosisDto? DyslexiaDiagnosis,
    EducationalDto EducationalGame,
    GameSessionDto[] GameSessions
);



