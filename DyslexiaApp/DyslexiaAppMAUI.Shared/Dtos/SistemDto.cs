namespace DyslexiaAppMAUI.Shared.Dtos;

public record SistemDto(
    Guid Id,
    string Layout,
    TimeSpan TimeSpent,
    string NavigationElements,
    SupportDto[] Supports
   // UserDto User // Assuming there is a UserRecord that represents the User entity

);



