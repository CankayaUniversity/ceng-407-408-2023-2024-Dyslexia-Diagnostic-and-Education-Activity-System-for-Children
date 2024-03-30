using DyslexiaAppMAUI.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DyslexiaApp.MAUI.Services;
public class AuthService
{
    private const string AuthKey = "AuthKey";
    public LoggedInUser User { get; private set; }
    public string? Token { get; private set; }

    public void Signin(AuthResponseDto dto)
    {
        var serialized= JsonSerializer.Serialize(dto);
        Preferences.Default.Set(AuthKey, serialized);
              
        (User, Token) = dto;
    }

    public void Initialize()
    {
        if (Preferences.Default.ContainsKey(AuthKey))
        {
            var serialized = Preferences.Default.Get<string?>(AuthKey, null);
            if (string.IsNullOrEmpty(serialized))
            {
                Preferences.Default.Remove(AuthKey);
            }
            else
            {
                try
                {
                    (User, Token) = JsonSerializer.Deserialize<AuthResponseDto>(serialized);
                }
                catch (JsonException ex)
                {
                    // Burada log yapabilir veya hata mesajını kullanıcıya gösterebilirsiniz.
                    Debug.WriteLine($"JSON Deserialization Error: {ex.Message}");
                }
            }
        }
    }
    public void Signout()
    {
        Preferences.Default.Remove(AuthKey);
        (User, Token) = (null, null);
    }

}
