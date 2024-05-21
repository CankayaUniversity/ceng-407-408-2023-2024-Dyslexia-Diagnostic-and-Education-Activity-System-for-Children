using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaAppMAUI.Shared.Dtos
{
    public record UpdateUserDto(string FirstName, string LastName, string Email, DateTime Birthday, string Gender);
}
