using System.Text.Json.Serialization;

namespace Blog.Application.Response;

public class PagingDataResponse<T> : IBaseResponse
{
	[JsonPropertyName("currentPage")]
	public int CurrentPage { get; set; }

	[JsonPropertyName("totalRow")]
	public int TotalRow { get; set; }

	[JsonPropertyName("data")]
	public List<T> Data { get; set; }
}
