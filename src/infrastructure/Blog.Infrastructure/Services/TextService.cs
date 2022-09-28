using Blog.Application.Services;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Blog.Infrastructure.Services
{
	public class TextService : BaseService, ITextService
	{
		public string Slug(string text)
		{
			if (String.IsNullOrWhiteSpace(text)) return null;

			string slugText = Regex.Replace(HttpUtility.HtmlDecode(text.Replace("&nbsp;", string.Empty)), "<.*?>", string.Empty);
			slugText = slugText.ToLower().Trim();
			slugText = slugText.Replace('ı', 'i')
				.Replace('ü', 'u')
				.Replace('ö', 'o')
				.Replace('ç', 'c')
				.Replace('ğ', 'g')
				.Replace('ş', 's');

			slugText = Regex.Replace(slugText, @"[^0-9a-z\s]+", string.Empty);
			slugText = Regex.Replace(slugText, @"\s+", "-");

			return slugText;
		}

		public string GenerateFileName(string name, string path)
		{
			int counter = 1;
			string newName = name, extension = "", tempName = "";

			string[] splitName = name.Split('.');

			extension = splitName.Last();

			tempName = String.Join("", splitName.Take(splitName.Length - 1));

			newName = tempName;

			while (System.IO.File.Exists(path + newName + "." + extension))
			{
				newName = tempName + "-" + (counter++).ToString();
			}

			return newName + "." + extension;
		}

		public string GeneratePassword(int length = 8)
		{
			const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!%-_?=*/()+";
			StringBuilder passwordText = new StringBuilder();

			Random random = new Random();

			while (0 < length--)
			{
				passwordText.Append(characters[random.Next(characters.Length)]);
			}

			return passwordText.ToString();
		}
	}
}
