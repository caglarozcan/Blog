using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Blog.Web.Helpers
{
	[HtmlTargetElement(Attributes = "is-active")]
	public class ActiveMenuHelper : TagHelper
	{
		[HtmlAttributeName("is-active")]
		public string url { get; set; }

		[HtmlAttributeNotBound, ViewContext]
		public ViewContext ViewContext { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			string currentPath = ViewContext.HttpContext.Request.Path;

			if (url.Contains(currentPath.Trim('/')))
			{
				output.Attributes.SetAttribute("class", "selected");
			}
		}
	}
}
