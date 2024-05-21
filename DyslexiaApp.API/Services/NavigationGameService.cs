using DyslexiaApp.API.Data.Entities;
using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DyslexiaApp.API.Services
{
    public class NavigationGameService
    {
        private readonly AppDbContext _context;
        private Random _random = new Random();

        public NavigationGameService(AppDbContext context)
        {
            _context = context;
        }

        // Oyun başlatma
        public async Task<NavigationGameDto> StartGameAsync()
        {
            // Örnek olarak geçerli bir DyslexiaDiagnosis kaydını almak veya oluşturmak
            var diagnosis = await _context.DyslexiaDiagnosis.FirstOrDefaultAsync();
            if (diagnosis == null)
            {
                diagnosis = new DyslexiaDiagnosis
                {
                    Id = Guid.NewGuid(),
                    // Diğer gerekli alanları doldurun
                    TestResults = 0,
                    FeedBack = "Initial feedback",
                    Description = "Initial description"
                };
                _context.DyslexiaDiagnosis.Add(diagnosis);
                await _context.SaveChangesAsync();
            }

            // Balonun konumunu rastgele belirle
            string balloonPosition = _random.Next(2) == 0 ? "Left" : "Right";

            var game = new NavigationGame
            {
                Id = Guid.NewGuid(),
                DyslexiaDiagnosis = diagnosis,
                BalloonPosition = balloonPosition
            };

            _context.NavigationGames.Add(game);
            await _context.SaveChangesAsync();

            return new NavigationGameDto(game.Id, new List<NavigationGameQuestionDto>(), balloonPosition);
        }
    }


        // Kullanıcının seçimini kontrol etme
        


        // Oyun için soruları yükleme
       
    
}
