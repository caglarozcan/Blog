namespace Blog.Application.Enums;

[Flags]
public enum ArticleSaveType : int
{
	Publish = 1,
	Draft = 2,
	PdfFile= 3
}
