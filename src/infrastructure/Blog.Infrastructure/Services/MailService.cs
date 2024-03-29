﻿using Blog.Application.Dto.SettingDto.BlogOptions;
using Blog.Application.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Blog.Infrastructure.Services;

public class MailService : IMailService
{
	private readonly IOptions<EmailOptions> _emailOptions;

	public MailService(IOptions<EmailOptions> emailOptions)
	{
		this._emailOptions = emailOptions;
	}

	public async ValueTask<bool> SendMail(string mailAddress, string subject, Dictionary<string, string> body, string template)
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
		mail.Sender = MailboxAddress.Parse(_emailOptions.Value.EmailHost);
		mail.To.Add(MailboxAddress.Parse(mailAddress));
		mail.Subject = subject;
		var builder = new BodyBuilder { HtmlBody = content };
		mail.Body = builder.ToMessageBody();

		try
		{
			SmtpClient SmtpServer = new SmtpClient();
			SmtpServer.Connect(_emailOptions.Value.EmailHost, _emailOptions.Value.EmailPort, SecureSocketOptions.StartTls);
			SmtpServer.Authenticate(_emailOptions.Value.EmailFrom, _emailOptions.Value.EmailPassword);


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
