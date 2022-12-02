using Blog.Application.Dto.SettingDto;
using Blog.Application.Repository;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	public class SettingGroupReadRepository : ReadRepository<SettingGroup>, ISettingGroupReadRepository
	{
		public SettingGroupReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}

		#region Read
		public async Task<List<BlogOptionsDto>> GetBlogOptionsAsync()
		{
			return await Table.Include(i => i.Settings).Select(s => new BlogOptionsDto()
			{
				SettingGroupKey = s.SettingKey,
				Options = s.Settings.Select(o => new BlogOptionsSubDto()
				{
					SettingKey = o.SettingKey,
					Value = o.Value
				}).ToList()
			}).ToListAsync();
		}

		public async Task<List<SettingGroupListDto>> GetSettingsAsync()
		{
			return await Table.Include(i => i.Settings).Select(s => new SettingGroupListDto()
			{
				Id = s.Id,
				Name = s.Name,
				Description = s.Description,
				SettingGroupKey = s.SettingKey,
				Settings = s.Settings.Select(t => new SettingsListDto()
				{
					Id = t.Id,
					SettingGroupId = t.SettingGroupId,
					Name = t.Name,
					Value = t.Value,
					SettingKey = t.SettingKey
				}).ToList()
			}).ToListAsync();
		}
		#endregion
	}
}
