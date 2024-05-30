using DyslexiaAppMAUI.Shared;
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

        [Post("/api/dyslexiadiagnosis/submit-answers")]
        Task<DyslexiaResultDto> SubmitAnswersAsync([Body] UserAnswersDto dto, string email);
    }
}