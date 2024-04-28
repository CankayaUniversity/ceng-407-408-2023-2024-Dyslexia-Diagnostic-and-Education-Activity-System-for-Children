using DyslexiaAppMAUI.Shared.Dtos;
using Refit;

namespace DyslexiaApp.MAUI.Services
{
    public interface IEducationalGameListApi 
    {
        [Get("/api/educationalgame")]
        Task<EducationalDto[]> GetEducationalGamesAsync();
    }
}
