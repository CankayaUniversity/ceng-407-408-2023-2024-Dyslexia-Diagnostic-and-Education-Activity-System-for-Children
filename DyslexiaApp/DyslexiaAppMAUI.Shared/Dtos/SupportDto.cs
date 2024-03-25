namespace DyslexiaAppMAUI.Shared.Dtos;

public record SupportDto(
    Guid Id,
    TimeSpan TimeSpent,
    string FAQs,
    string ContactString,
    string Message,
    string SupportStatus,
    SistemDto Sistem
);



