namespace Blog.Application.Services
{
	public interface IMailService
	{
		Task<bool> SendMail(string mailAddress, string subject, Dictionary<string, string> body, string template);
	}
}
