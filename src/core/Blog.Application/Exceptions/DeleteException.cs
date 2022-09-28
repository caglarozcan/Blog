namespace Blog.Application.Exceptions
{
	public class DeleteException : Exception
	{
		public DeleteException(string message) 
			: base(String.IsNullOrWhiteSpace(message) ? "Silme işlemi sırasında bir hata oluştu." : message)
		{}
	}
}
