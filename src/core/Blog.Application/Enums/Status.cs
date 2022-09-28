namespace Blog.Application.Enums
{
	[Flags]
	public enum Status : byte
	{
		Passive = 0,
		Active = 1,
		Deleted = 2,
		Waiting = 3
	}
}
