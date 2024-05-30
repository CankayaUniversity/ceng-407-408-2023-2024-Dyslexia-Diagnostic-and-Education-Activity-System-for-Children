using DyslexiaAppMAUI.Shared.Models;

namespace DyslexiaAppMAUI.Shared.Dtos;

public record LoggedInUser(Guid Id ,string Name, string Email,string LastName,DateTime Birthday,string Gender,int Accuracy);



