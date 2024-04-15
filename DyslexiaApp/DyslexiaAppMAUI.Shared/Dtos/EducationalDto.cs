namespace DyslexiaAppMAUI.Shared.Dtos;

public record EducationalDto(
    Guid Id,
    string Name,
    string Description,
    GameSessionDto[] GameSessions
);



