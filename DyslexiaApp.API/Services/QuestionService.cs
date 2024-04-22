using DyslexiaApp.API.Data;
using DyslexiaApp.API.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        // Tüm soruları getir
        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _context.Questions
                                 .Include(q => q.MainImage)
                                 .Include(q => q.ImageOptions)
                                 .ToListAsync();
        }

        // ID'ye göre tek bir soru getir
        public async Task<Question> GetQuestionByIdAsync(Guid questionId)
        {
            return await _context.Questions
                                 .Include(q => q.MainImage)
                                 .Include(q => q.ImageOptions)
                                 .FirstOrDefaultAsync(q => q.Id == questionId);
        }

        // Yeni soru ekle
        public async Task<Question> AddQuestionAsync(Question question)
        {
            if (question == null)
                throw new ArgumentNullException(nameof(question));

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        // Soru güncelle
        public async Task<Question> UpdateQuestionAsync(Guid questionId, string newQuestionText, int newCorrectAnswerIndex)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null)
                throw new InvalidOperationException("Soru bulunamadı");

            question.QuestionText = newQuestionText;
            question.CorrectAnswerIndex = newCorrectAnswerIndex;

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }

        // Soru sil
        public async Task<bool> DeleteQuestionAsync(Guid questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null)
                return false;

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
