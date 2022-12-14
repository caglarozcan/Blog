namespace Blog.Application.Services;

public interface ITextService
{
	string Slug(string text);

	string GenerateFileName(string name, string path);

	string GeneratePassword(int length = 8);
}
