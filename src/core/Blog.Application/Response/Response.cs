using System.Text.Json;
using System.Text.Json.Serialization;

namespace Blog.Application.Response
{
	public class Response : IBaseResponse
	{
		public Response()
		{}

		public Response(string message, bool success)
		{
			this.Message = message;
			this.Success = success;
		}

		[JsonPropertyName("message")]
		public string Message { get; set; }

		[JsonPropertyName("success")]
		public bool Success { get; set; }

		public override string ToString()
		{
			return JsonSerializer.Serialize(this);
		}
	}

	public class Response<T> : Response, IBaseResponse
	{
		public Response(string message, bool success)
			: base(message, success)
		{}

		public Response(string message, bool success, T value)
			: base(message, success)
		{
			Value = value;
		}

		[JsonPropertyName("value")]
		public T Value { get; set; }
	}
}
