using DyslexiaApp.API.Endpoints;
using DyslexiaApp.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;




namespace DyslexiaApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database and JWT Authentication Setup
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions =>
                jwtOptions.TokenValidationParameters = TokenService.GetTokenValidationParameters(builder.Configuration)
            );

            // Additional Service Configurations
            builder.Services.AddAuthorization();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddTransient<TokenService>()
                            .AddTransient<PasswordService>()
                            .AddTransient<AuthService>()
                            .AddTransient<DyslexiaDiagnosisService>()
                            .AddTransient<EducationalGameService>()
                            .AddTransient<QuestionService>();

            var app = builder.Build();

            // Application Middleware and Endpoint Configuration
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapEndpoints();
            app.MapControllers();
            app.Run();
        }
    }
}




