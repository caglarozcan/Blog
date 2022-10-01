using Blog.Application.Dto.UserDto;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Infrastructure.Services
{
	public class UserService : BaseService, IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ITextService _textService;
		private readonly IHashService _hashService;
		private readonly IMailService _mailService;

		public UserService(IUnitOfWork unitOfWork, ITextService textService, IHashService hashService, IMailService mailService)
		{
			this._unitOfWork = unitOfWork;
			this._textService = textService;
			this._hashService = hashService;
			this._mailService = mailService;
		}

		#region Create
		public async Task<Response<ProblemDetails>> InsertAsync(UserInsertDto data, ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			if (await _unitOfWork.UserReadRepository.AnyAsync(u => u.Email.Equals(data.Email.Trim())))
			{
				return new Response<ProblemDetails>(message: "Girilen mail adresi sistemde tanımlı. Başka bir mail adresi giriniz.", success: false);
			}

			if (String.IsNullOrWhiteSpace(data.Slug))
			{
				data.Slug = _textService.Slug(data.Name + " " + data.LastName);
			}

			if (await _unitOfWork.UserReadRepository.AnyAsync(u => u.Slug.Equals(data.Slug)))
			{
				return new Response<ProblemDetails>(message: "Girilen slug sistemde tanımlı.", success: false);
			}

			data.Password = _hashService.Hash(data.Password);

			await _unitOfWork.UserWriteRepository.InsertAsync(new Domain.Entities.User()
			{
				Name = data.Name.Trim(),
				LastName = data.LastName.Trim(),
				NickName = data.NickName.Trim(),
				Email = data.Email.Trim(),
				Password = _hashService.Hash(data.Password),
				CreatedDate = DateTime.Now,
				Slug = data.Slug.Trim(),
				Status = (byte)data.Status
			});

			int result = await _unitOfWork.SaveAsync();

			if (result == 1)
			{
				//TODO : burada kullanıcı bilgileri mail ile gönderilecek.

				return new Response<ProblemDetails>(message: "Kullanıcı başarıyla eklendi.", success: true);
			}
			else
			{
				return new Response<ProblemDetails>(message: "Kullanıcı ekleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);
			}

		}
		#endregion

		#region Read
		public async Task<PagingDataResponse<UserListDto>> GetUserListAsync(DataListRequest request)
		{
			var userList = await _unitOfWork.UserReadRepository.GetUserListAsync(request);

			return userList;
		}
		#endregion
	}
}
