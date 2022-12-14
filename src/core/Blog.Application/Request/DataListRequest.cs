using Blog.Application.Enums;

namespace Blog.Application.Request;

public class DataListRequest
{
	public int? Page { get; set; } = 1;

	public int? PerData { get; set; } = 15;

	public Sorting? SortType { get; set; } = Sorting.Ascending;

	public int? SortIndex { get; set; } = null;

	public string SearchValue { get; set; } = String.Empty;
}
