namespace Blog.Application.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string dataName)
			: base($"İşlem yapmak istediğiniz {dataName} sistemde bulunamadı.") 
		{ 
		}
	}
}
