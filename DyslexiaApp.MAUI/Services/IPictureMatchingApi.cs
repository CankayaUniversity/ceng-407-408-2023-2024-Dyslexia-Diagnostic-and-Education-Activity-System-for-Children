using DyslexiaAppMAUI.Shared.Dtos;
using Refit;

namespace DyslexiaApp.MAUI.Services
{
    public interface IPictureMatchingApi
    {
        [Get("/api/question/{questionId}")]
        Task<QuestionDto> GetQuestionByIdAsync(Guid questionId);

        [Get("/api/question")]
        Task<List<QuestionDto>> GetAllQuestionsAsync();
    }

}