using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Dto.CategoryDto
{
	public class CategoryListDto
	{
		public Guid Id { get; set; }

		public Guid? ParentId { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string Icon { get; set; }

		public string Color { get; set; }

		public string Slug { get; set; }

		public DateTime CreatedDate { get; set; }

		public byte Status { get; set; }
	}
}
