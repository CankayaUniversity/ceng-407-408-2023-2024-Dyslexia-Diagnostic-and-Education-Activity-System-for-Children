using DyslexiaAppMAUI.Shared.Dtos;
using Refit;

namespace DyslexiaApp.MAUI.Services
{
    public interface IEducationalGameListApi
    {
        [Get("/api/educationalgame")]
        Task<EducationalDto[]> GetEducationalGamesAsync();

        [Get("/api/question/")]
        Task<List<QuestionDto>> GetAllQuestionsAsync();
    }
}