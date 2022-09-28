namespace Blog.Application.Exceptions
{
	public class UpdateException : Exception
	{
		public UpdateException(string message)
			: base(String.IsNullOrWhiteSpace(message) ? "Güncelleme işlemi sırasında bir hata oluştu." : message)
		{
		}
	}
}
