namespace Blog.Application.Exceptions
{
	public class InvalidAuthInfoException : Exception
	{
		public InvalidAuthInfoException()
			: base("Kullanıcı adı veya şifre hatalı.")
		{}
	}
}
