namespace DyslexiaAppMAUI.Shared.Dtos;

public record struct DyslexiaDiagnosisDto(
    Guid Id,
    int TestResults,
    string FeedBack,
    string Description,
    MatchingGameDto[] MatchingGames,
    NavigationGameDto[] NavigationGames
);



