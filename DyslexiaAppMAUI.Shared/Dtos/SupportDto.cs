namespace DyslexiaAppMAUI.Shared.Dtos;

public record SupportDto(
    Guid Id,
    string FAQs,
    string ContactString,
    string Message,
    string SupportStatus,
    SistemDto Sistem
);



