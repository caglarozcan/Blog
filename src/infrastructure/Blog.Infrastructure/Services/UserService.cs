using Blog.Application.Dto.UserDto;
using Blog.Application.Enums;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Blog.Domain.Entities;
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

			var role = await _unitOfWork.RoleReadRepository.GetAsync(r => r.Id.Equals(data.RoleId));

			if (role != null)
			{
				data.Password = _hashService.Hash(data.Password);

				var user = new Domain.Entities.User()
				{
					Name = data.Name.Trim(),
					LastName = data.LastName.Trim(),
					NickName = data.NickName.Trim(),
					Email = data.Email.Trim(),
					Password = _hashService.Hash(data.Password),
					CreatedDate = DateTime.Now,
					Slug = data.Slug.Trim(),
					Status = (byte)data.Status
				};

				user.Roles.Add(new Domain.Entities.UserRoles()
				{
					User = user,
					Role = role
				});

				await _unitOfWork.UserWriteRepository.InsertAsync(user);

				int result = await _unitOfWork.SaveAsync();

				if (result > 0)
				{
					//TODO : burada kullanıcı bilgileri mail ile gönderilecek.
					return new Response<ProblemDetails>(message: "Kullanıcı başarıyla eklendi.", success: true);
				}
				else
				{
					return new Response<ProblemDetails>(message: "Kullanıcı ekleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);
				}
			}
			else
			{
				return new Response<ProblemDetails>(message: "Gönderilen rol bilgisi sistemde tanımlı değil.", success: false);
			}
		}
		#endregion

		#region Read
		public async Task<PagingDataResponse<UserListDto>> GetUserListAsync(DataListRequest request)
		{
			var userList = await _unitOfWork.UserReadRepository.GetUserListAsync(request);

			return userList;
		}

		public async Task<UserUpdateDto> GetUpdatedUserAsync(Guid id)
		{
			var user = await _unitOfWork.UserReadRepository.GetAsync(u => u.Id.Equals(id), i => i.Roles);

			return new UserUpdateDto()
			{
				Id = user.Id,
				Name = user.Name,
				LastName = user.LastName,
				Email = user.Email,
				NickName = user.NickName,
				Slug = user.Slug,
				Status = (Status)user.Status,
				RoleId = user.Roles.Count() > 0 ? user.Roles.First().RoleId : null
			};
		}
		#endregion

		#region Update
		public async Task<Response<ProblemDetails>> UpdateAsync(UserUpdateDto data, ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			if (false.Equals(await _unitOfWork.UserReadRepository.AnyAsync(u => u.Id.Equals(data.Id))))
			{
				return new Response<ProblemDetails>(message: "İşlem yapmak istediğiniz kullanıcı bilgileri sistemde bulunamadı.", success: false);
			}

			if (await _unitOfWork.UserReadRepository.AnyAsync(u => u.Email.Equals(data.Email.Trim()) && !u.Id.Equals(data.Id)))
			{
				return new Response<ProblemDetails>(message: "Girilen mail adresi sistemde tanımlı. Başka bir mail adresi giriniz.", success: false);
			}

			var user = await _unitOfWork.UserReadRepository.GetAsync(u => u.Id.Equals(data.Id), i => i.Roles);
			user.Name = data.Name.Trim();
			user.LastName = data.LastName.Trim();
			user.Email = data.Email.Trim();
			user.NickName = data.NickName.Trim();
			user.UpdatedDate = DateTime.Now;
			user.Status = (byte)data.Status;
			user.Slug = String.IsNullOrWhiteSpace(data.Slug) ? _textService.Slug(data.Name + " " + data.LastName) : data.Slug;

			if (!String.IsNullOrWhiteSpace(data.Password))
			{
				user.Password = _hashService.Hash(data.Password);
			}

			if (data.RoleId.HasValue)
			{
				var role = await _unitOfWork.RoleReadRepository.GetAsync(r => r.Id.Equals(data.RoleId));

				if (role != null)
				{
					if (user.Roles.Count() > 0)
					{
						user.Roles.Remove(user.Roles.First());
						user.Roles.Add(new Domain.Entities.UserRoles()
						{
							User = user,
							Role = role
						});
					}
					else
					{
						user.Roles.Add(new Domain.Entities.UserRoles()
						{
							User = user,
							Role = role
						});
					}
				}
				else
				{
					return new Response<ProblemDetails>(message: "Gönderilen rol bilgisi sistemde tanımlı değil.", success: false);
				}
			}

			await _unitOfWork.UserWriteRepository.UpdateAsync(user);
			
			int result = await _unitOfWork.SaveAsync();

			if (result > 0)
			{
				return new Response<ProblemDetails>(message: "Kullanıcı bilgileri başarıyla güncellendi.", success: true);
			}
			else
			{
				return new Response<ProblemDetails>(message: "Kullanıcı bilgileri güncelleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);
			}
		}
		#endregion
	}
}
