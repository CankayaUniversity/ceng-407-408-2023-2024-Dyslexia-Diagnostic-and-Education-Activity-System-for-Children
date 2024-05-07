using DyslexiaApp.API.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using System.Threading.Tasks;

public class SendGridEmailService : IEmailService
{
    private readonly string _apiKey;

    public SendGridEmailService(string apiKey)
    {
        _apiKey = apiKey;
    }

    public async Task SendEmailAsync(string to, string subject, string body)
    {
        var client = new SendGridClient(_apiKey);
        var from = new EmailAddress("dyslexiagameapplication@gmail.com", "Dyslexia Game Application");
        var toEmail = new EmailAddress(to);
        var msg = MailHelper.CreateSingleEmail(from, toEmail, subject, body, body);
        var response = await client.SendEmailAsync(msg);
    }
}