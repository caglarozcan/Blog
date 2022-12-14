using Blog.Application.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Blog.Infrastructure.Services;

public class MailService : IMailService
{
	private readonly IConfiguration _configuration;

	public MailService(IConfiguration configuration)
	{
		this._configuration = configuration;
	}

	public async Task<bool> SendMail(string mailAddress, string subject, Dictionary<string, string> body, string template)
	{
		string content = "Merhaba [uname]... Şifre sıfırlama bağlantınız: [key]";
		/*using (System.IO.StreamReader streamReader = new System.IO.StreamReader(template, Encoding.GetEncoding("UTF-8")))
		{
			content = streamReader.ReadToEnd();
		}*/

		foreach (var key in body)
		{
			content = content.Replace(key.Key, key.Value);
		}

		MimeMessage mail = new MimeMessage();
		mail.Sender = MailboxAddress.Parse(_configuration["SMTP:Host"]);
		mail.To.Add(MailboxAddress.Parse(mailAddress));
		mail.Subject = subject;
		var builder = new BodyBuilder { HtmlBody = content };
		mail.Body = builder.ToMessageBody();

		try
		{
			SmtpClient SmtpServer = new SmtpClient();
			SmtpServer.Connect(_configuration["SMTP:Host"], int.Parse(_configuration["SMTP:Port"]), SecureSocketOptions.StartTls);
			SmtpServer.Authenticate(_configuration["SMTP:Ema'l"], _configuration["SMTP:Password"]);


			await SmtpServer.SendAsync(mail);
			await SmtpServer.DisconnectAsync(true);
		}
		catch (Exception ex)
		{
			return false;
		}

		return true;
	}
}
