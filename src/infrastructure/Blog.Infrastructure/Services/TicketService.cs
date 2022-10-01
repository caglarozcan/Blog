using Blog.Application.Dto.TagsDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Infrastructure.Services
{
	public class TicketService : BaseService, ITicketService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITextService _textService;

		public TicketService(IUnitOfWork unitOfWork, ITextService textService)
		{
			this._unitOfWork = unitOfWork;
			this._textService = textService;
		}

		#region Create
		public async Task<Response<ProblemDetails>> InsertAsync(TagInsertDto data, ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			if (String.IsNullOrWhiteSpace(data.Slug))
				data.Slug = _textService.Slug(data.Title);

			if (await _unitOfWork.TicketReadRepository.AnyAsync(c => c.Title.Equals(data.Title.Trim()) || c.Slug.Equals(data.Slug.Trim())))
			{
				return new Response<ProblemDetails>(message: "Aynı isimde kategori sistemde tanımlı. Farklı bir isim giriniz.", success: false);
			}
			else
			{
				await _unitOfWork.TicketWriteRepository.InsertAsync(new Domain.Entities.Ticket()
				{
					Title = data.Title.Trim(),
					Slug = data.Slug.Trim(),
					Status = data.Status,
					CreatedDate = DateTime.Now
				});

				int result = await _unitOfWork.SaveAsync();

				if (result == 1)
				{
					return new Response<ProblemDetails>(message: "Etiket başarıyla eklendi.", success: true);
				}
				else
				{
					return new Response<ProblemDetails>(message: "Etiket ekleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);
				}
			}
		}
		#endregion

		#region Read
		public async Task<PagingDataResponse<TagListDto>> ListAsync(DataListRequest request)
		{
			var ticketList = await _unitOfWork.TicketReadRepository.ListAsync(request);

			return ticketList;
		}

		public async Task<Response<TagListDto>> GetUpdatedTicketAsync(Guid id)
		{
			bool ticketExists = await _unitOfWork.TicketReadRepository.AnyAsync(a => a.Id.Equals(id));

			if (false.Equals(ticketExists))
				return new Response<TagListDto>("İşlem yapmak istediğiniz etiket sistemde bulunamadı.", false);

			var ticket = await _unitOfWork.TicketReadRepository.GetAsync(c => c.Id.Equals(id));

			return new Response<TagListDto>("Etiket bilgileri.", true, new TagListDto()
			{
				Id = ticket.Id,
				Slug = ticket.Slug,
				Status = ticket.Status,
				Title = ticket.Title
			});
		}
		#endregion

		#region Update
		public async Task<Response<ProblemDetails>> EditAsync(TagEditDto data, ModelStateDictionary modelState)
		{
			if (false.Equals(modelState.IsValid))
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			if (String.IsNullOrWhiteSpace(data.Slug))
				data.Slug = _textService.Slug(data.Title);

			if (await _unitOfWork.TicketReadRepository.AnyAsync(c => !c.Id.Equals(data.Id) && (c.Title.Equals(data.Title) || c.Slug.Equals(data.Slug))))
			{
				return new Response<ProblemDetails>(message: "Aynı isimde etiket sistemde tanımlı. Farklı bir isim giriniz.", success: false);
			}
			else
			{
				var ticket = await _unitOfWork.TicketReadRepository.GetAsync(c => c.Id.Equals(data.Id));

				if (ticket != null)
				{
					ticket.Title = data.Title;
					ticket.UpdatedDate = DateTime.Now;
					ticket.Slug = data.Slug;
					ticket.Status = data.Status;

					await _unitOfWork.TicketWriteRepository.UpdateAsync(ticket);

					int result = await _unitOfWork.SaveAsync();

					if (result == 1)
					{
						return new Response<ProblemDetails>(message: "Etiket başarıyla güncellendi.", success: true);
					}
					else
					{
						return new Response<ProblemDetails>(message: "Etiket güncelleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);
					}
				}
				else
				{
					return new Response<ProblemDetails>(message: "Güncellemek istediğiniz etiket sistemde bulunamadı.", success: false);
				}
			}
		}
		#endregion

		#region Delete
		public async Task<Response> DeleteAsync(Guid id)
		{
			bool ticketExists = await _unitOfWork.TicketReadRepository.AnyAsync(a => a.Id.Equals(id));

			if (false.Equals(ticketExists))
				return new Response("İşlem yapmak istediğiniz etiket sistemde bulunamadı.", false);

			var ticket = await _unitOfWork.TicketReadRepository.GetAsync(c => c.Id.Equals(id));

			await _unitOfWork.TicketWriteRepository.DeleteAsync(ticket);

			int result = await _unitOfWork.SaveAsync();

			if (!result.Equals(1))
				return new Response("Etiket silme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", false);

			return new Response("Etiket başarıyla silinmiştir.", true);
		}
		#endregion
	}
}
