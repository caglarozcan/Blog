namespace Blog.Application.Exceptions
{
	public class InsertException : Exception
	{
		public InsertException(string message)
			: base(String.IsNullOrWhiteSpace(message) ? "Ekleme işlemi sırasında bir hata oluştu." : message)
		{
		}
	}
}
