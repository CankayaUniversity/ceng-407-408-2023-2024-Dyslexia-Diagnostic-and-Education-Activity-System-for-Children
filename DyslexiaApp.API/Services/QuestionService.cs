using DyslexiaApp.API.Data;
using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DyslexiaApp.API.Services
{
    public class QuestionService
    {
        private readonly AppDbContext _context;

        public QuestionService(AppDbContext context)
        {
            _context = context;
        }

        // Convert Image entity to ImageDto
        private ImageDto MapImageToDto(Image image)
        {
            if (image == null) return null;
            return new ImageDto
            {
                Id = image.Id,
                Url = image.Url,
                Description = image.Description
            };
        }

        // Get all questions
        public async Task<List<QuestionDto>> GetAllQuestionsAsync()
        {
            var questions = await _context.Questions
                                          .Include(q => q.MainImage)
                                          .Include(q => q.ImageOptions)
                                          .ToListAsync();

            return questions.Select(q => new QuestionDto
            {
                Id = q.Id,
                QuestionText = q.QuestionText,
                MainImage = MapImageToDto(q.MainImage),
                ImageOptions = q.ImageOptions.Select(MapImageToDto).ToList(),
                CorrectAnswerIndex = q.CorrectAnswerIndex
            }).ToList();
        }

        // Get a single question by ID
        public async Task<QuestionDto> GetQuestionByIdAsync(Guid questionId)
        {
            var question = await _context.Questions
                                         .Include(q => q.MainImage)
                                         .Include(q => q.ImageOptions)
                                         .FirstOrDefaultAsync(q => q.Id == questionId);

            return question == null ? null : new QuestionDto
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                MainImage = MapImageToDto(question.MainImage),
                ImageOptions = question.ImageOptions.Select(MapImageToDto).ToList(),
                CorrectAnswerIndex = question.CorrectAnswerIndex
            };
        }

        // Add a new question
        public async Task<QuestionDto> AddQuestionAsync(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            return new QuestionDto
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                MainImage = MapImageToDto(question.MainImage),
                ImageOptions = question.ImageOptions.Select(MapImageToDto).ToList(),
                CorrectAnswerIndex = question.CorrectAnswerIndex
            };
        }

        // Update a question
        public async Task<QuestionDto> UpdateQuestionAsync(Guid questionId, string newQuestionText, int newCorrectAnswerIndex)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null)
                throw new InvalidOperationException("Question not found");

            question.QuestionText = newQuestionText;
            question.CorrectAnswerIndex = newCorrectAnswerIndex;

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();

            return new QuestionDto
            {
                Id = question.Id,
                QuestionText = question.QuestionText,
                MainImage = MapImageToDto(question.MainImage),
                ImageOptions = question.ImageOptions.Select(MapImageToDto).ToList(),
                CorrectAnswerIndex = question.CorrectAnswerIndex
            };
        }

        // Delete a question
        public async Task<bool> DeleteQuestionAsync(Guid questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null)
                return false;

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }

        public Question MapDtoToQuestion(QuestionDto dto)
        {
            return new Question
            {
                // Assuming Question has similar properties to QuestionDto
                Id = dto.Id,
                QuestionText = dto.QuestionText,
                MainImage = MapDtoToImage(dto.MainImage),  // Assuming you have a similar mapper for ImageDto to Image
                ImageOptions = dto.ImageOptions.Select(MapDtoToImage).ToList(),
                CorrectAnswerIndex = dto.CorrectAnswerIndex
            };
        }

        public Image MapDtoToImage(ImageDto dto)
        {
            if (dto == null) return null;
            return new Image
            {
                Id = dto.Id,
                Url = dto.Url,
                Description = dto.Description
            };
        }

    }
}