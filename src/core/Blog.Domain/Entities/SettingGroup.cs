using System.Linq.Expressions;

namespace Blog.Domain.Entities
{
	public class SettingGroup : BaseEntity
	{
		public SettingGroup()
		{
			this.Settings = new HashSet<Settings>();
		}

		public string Name { get; set; }

		public string Description { get; set; }

		public virtual ICollection<Settings> Settings { get; set; }
	}
}
