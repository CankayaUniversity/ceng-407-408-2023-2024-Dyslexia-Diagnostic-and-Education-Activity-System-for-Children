using DyslexiaAppMAUI.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DyslexiaApp.API.Services
{
    public class DyslexiaDiagnosisService
    {
        private readonly AppDbContext _context;

        // Constructor düzgün bir şekilde tanımlanmalıdır.
        public DyslexiaDiagnosisService(AppDbContext context)
        {
            _context = context;
        }

      
    }
}
