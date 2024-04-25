using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using MimeKit;
using TravelAgency.DTOs.EmailDTOs;
using TravelAgency.DTOs.PdfDTOs;

namespace TravelAgency.Services.Emails
{
    public class EmailService : IEmailService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly string _emailServer;
        private readonly int _emailPort;
        private readonly string _emailUsername;
        private readonly string _emailPassword;
        private readonly string _configTemplatePath;

        public EmailService(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _environment = environment;
            _emailServer = configuration["Mail:Server"] ?? string.Empty;
            int.TryParse(configuration["Mail:Port"], out _emailPort);
            _emailUsername = configuration["Mail:Username"] ?? string.Empty;
            _emailPassword = configuration["Mail:Password"] ?? string.Empty;
            _configTemplatePath = $"{environment.ContentRootPath}Config/EmailTemplate.html";
        }

        public async Task SendBasicEmail(BasicEmailDto dto)
        {
            MimeMessage message = CreateMessage(dto);

            using StreamReader streamReader = new StreamReader(_configTemplatePath);
            string template = await streamReader.ReadToEndAsync();
            template = template.Replace("__EmailTitle__", dto.Title);
            template = template.Replace("__EmailBody__", dto.Body);
            template = template.Replace("__EmailCompany__", dto.From);
            template = template.Replace("__EmailSender__", dto.ReplyTo);

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = template;
            message.Body = bodyBuilder.ToMessageBody();

            await SendMessage(message);
        }

        public async Task SendWithAttachment(BasicEmailDto dto, GenerateResponse file)
        {
            MimeMessage message = CreateMessage(dto);

            using StreamReader streamReader = new StreamReader(_configTemplatePath);
            string template = await streamReader.ReadToEndAsync();
            template = template.Replace("__EmailTitle__", dto.Title);
            template = template.Replace("__EmailBody__", dto.Body);
            template = template.Replace("__EmailCompany__", dto.From);
            template = template.Replace("__EmailSender__", dto.ReplyTo);

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = template;

            bodyBuilder.Attachments.Add(file.FileName, file.File);

            message.Body = bodyBuilder.ToMessageBody();

            await SendMessage(message);
        }

        private MimeMessage CreateMessage(BasicEmailDto dto)
        {
            MimeMessage message = new MimeMessage();
            message.Sender = new MailboxAddress(dto.From, _emailUsername);
            message.To.Add(new MailboxAddress(dto.SendTo, dto.SendTo));
            message.From.Add(new MailboxAddress(dto.From, dto.ReplyTo));
            message.ReplyTo.Add(new MailboxAddress(dto.From, dto.ReplyTo));
            message.Subject = dto.Subject;
            return message;
        }

        private async Task SendMessage(MimeMessage message)
        {
            using SmtpClient smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_emailServer, _emailPort, SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(_emailUsername, _emailPassword);
            await smtpClient.SendAsync(message);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
