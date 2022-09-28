namespace Blog.Application.Services
{
	public interface IHashService
	{
		string Hash(string text);

		bool Compare(string text, string hashedText);
	}
}
