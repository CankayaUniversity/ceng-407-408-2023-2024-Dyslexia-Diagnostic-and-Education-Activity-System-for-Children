namespace DyslexiaAppMAUI.Shared.Dtos;

public record SistemDto(
    Guid Id,
    string Layout,
    string NavigationElements,
    SupportDto[] Supports
   // UserDto User // Assuming there is a UserRecord that represents the User entity

);



