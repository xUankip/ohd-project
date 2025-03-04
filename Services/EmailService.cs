using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

public class EmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public async Task SendEmailAsync(string subject, string body)
    {
        var emailSettings = _config.GetSection("EmailSettings");
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress("Admin", emailSettings["SenderEmail"]));
        message.To.Add(new MailboxAddress("", emailSettings["ReceiverEmail"]));
        message.Subject = subject;

        message.Body = new TextPart("plain")
        {
            Text = body
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(emailSettings["SmtpServer"], 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(emailSettings["SenderEmail"], emailSettings["SenderPassword"]);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
