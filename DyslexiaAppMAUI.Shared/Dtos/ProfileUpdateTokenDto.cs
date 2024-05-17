using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DyslexiaAppMAUI.Shared.Dtos;
public class ProfileUpdateTokenDto
{
    public string Token { get; set; }

    public ProfileUpdateTokenDto(string token)
    {
        Token = token;
    }
}