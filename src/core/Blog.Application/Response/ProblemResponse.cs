using System.Text.Json.Serialization;

namespace Blog.Application.Response;

public class ProblemResponse : IBaseResponse
{
	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("reasons")]
	public List<string> Reasons { get; set; }
	
	public ProblemResponse()
	{
		Reasons = new List<string>();
	}
}
