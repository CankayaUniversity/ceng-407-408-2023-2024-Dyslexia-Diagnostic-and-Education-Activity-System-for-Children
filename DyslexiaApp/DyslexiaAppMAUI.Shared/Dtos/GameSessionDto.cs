namespace DyslexiaAppMAUI.Shared.Dtos;

public record GameSessionDto(
    Guid Id,
    TimeSpan TimeSpent,
    int SessionScore
);



