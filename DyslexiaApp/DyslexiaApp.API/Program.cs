
using DyslexiaApp.API.Endpoints;
using DyslexiaApp.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace DyslexiaApp.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(jwtOptions =>
                jwtOptions.TokenValidationParameters = TokenService.GetTokenValidationParameters(builder.Configuration)
            );


        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddTransient<TokenService>()
                        .AddTransient<PasswordService>()
                        .AddTransient<AuthService>();


        var app = builder.Build();

#if DEBUG
        MigrateDatabase(app.Services);
#endif
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

#if !DEBUG
        app.UseHttpsRedirection();
#endif
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapEndpoints();

        app.MapControllers();

        app.Run();
    }
    static void MigrateDatabase(IServiceProvider serviceProvider)
    {
        var scope = serviceProvider.CreateScope();
        var dataContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (dataContext.Database.GetPendingMigrations().Any())
            dataContext.Database.Migrate();
    }
}




