﻿using Blog.Application.Dto;
using Blog.Application.Dto.MediaTypeDto;
using Blog.Application.Extension.Pagination;
using Blog.Application.Extension.PredicateBuilder;
using Blog.Application.Repository;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Persistence.Repository
{
	internal class MediaTypeReadRepository : ReadRepository<MediaType>, IMediaTypeReadRepository
	{
		public MediaTypeReadRepository(DbContext dbContext) 
			: base(dbContext)
		{
		}

		public async Task<PagingDataResponse<MediaTypeListDto>> GetMediaTypeListAsync(DataListRequest request)
		{
			var query = Table.Select(s => new MediaTypeListDto()
			{
				Id = s.Id,
				Title = s.Title,
				MimeType = s.MimeType,
				FileExtension = s.FileExtension,
				CreatedDate = s.CreatedDate,
				Status = s.Status
			});

			if (!String.IsNullOrWhiteSpace(request.SearchValue))
			{
				query = query.WherePredicate(request.SearchValue);
			}

			if (request.SortType.HasValue)
			{
				query = query.OrderByPredicate(request.SortIndex.Value, request.SortType.Value);
			}

			return await query.ToPagingData(request.PerData, request.Page);
		}

		public async Task<List<MediaTypeWhiteListDto>> GetMediaTypeWhiteListAsync()
		{
			return await Table.Where(m => m.Status == 1).Select(s => new MediaTypeWhiteListDto()
			{
				Id = s.Id,
				FileExtension = s.FileExtension,
				MimeType = s.MimeType,
				UploadDir = s.UploadDir
			}).ToListAsync();
		}

		public async Task<MediaTypeSelectDto> GetMediaTypeSelectAsync(Guid? id)
		{
			return new MediaTypeSelectDto()
			{
				MediaTypeId = id,
				Options = await Table.Select(s => new SelectOptionsDto()
				{
					Text = s.Title,
					Value = s.Id.ToString()
				}).ToListAsync()
			};
		}
	}
}
