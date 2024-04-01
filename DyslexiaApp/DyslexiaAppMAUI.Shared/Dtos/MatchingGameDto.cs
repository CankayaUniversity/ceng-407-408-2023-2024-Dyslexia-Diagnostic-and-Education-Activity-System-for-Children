namespace DyslexiaAppMAUI.Shared.Dtos;

public record struct MatchingGameDto(
    Guid Id,
    DyslexiaDiagnosisDto? DyslexiaDiagnosis,
    EducationalDto EducationalGame,
    GameSessionDto[] GameSessions
);



