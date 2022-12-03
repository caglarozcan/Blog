using Blog.Application.Dto.SettingDto;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Infrastructure.Services
{
	public class SettingService : BaseService, ISettingService
	{
		private readonly IUnitOfWork _unitOfWork;

		public SettingService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		#region Create

		#endregion

		#region Read
		public async Task<List<SettingGroupListDto>> GetSettingsAsync()
		{
			return await _unitOfWork.SettingGroupReadRepository.GetSettingsAsync();
		}
		#endregion

		#region Update
		public async Task<Response<ProblemDetails>> SaveArticleSettingsAsync(ArticleSettingUpdateDto data, ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			foreach (var item in data.GetType().GetProperties())
			{
				var setting = await _unitOfWork.SettingsReadRepository.GetAsync(s => s.SettingKey.Equals(item.Name));
				if (setting != null)
				{
					setting.Value = item.GetValue(data, null).ToString();
					await _unitOfWork.SettingsWriteRepository.UpdateAsync(setting);
					await _unitOfWork.SaveAsync();
				}
			}

			return new Response<ProblemDetails>(message: "Güncelleme işlemi başarılı.", success: true);
		}

		public async Task<Response<ProblemDetails>> SaveCommentSettingsAsync(CommentSettingUpdateDto data, ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			foreach (var item in data.GetType().GetProperties())
			{
				var setting = await _unitOfWork.SettingsReadRepository.GetAsync(s => s.SettingKey.Equals(item.Name));
				if (setting != null)
				{
					setting.Value = item.GetValue(data, null).ToString();
					await _unitOfWork.SettingsWriteRepository.UpdateAsync(setting);
					await _unitOfWork.SaveAsync();
				}
			}

			return new Response<ProblemDetails>(message: "Güncelleme işlemi başarılı.", success: true);
		}

		public async Task<Response<ProblemDetails>> SaveFileUploadSettingsAsync(FileUploadSettingUpdateDto data, ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			foreach (var item in data.GetType().GetProperties())
			{
				var setting = await _unitOfWork.SettingsReadRepository.GetAsync(s => s.SettingKey.Equals(item.Name));
				if (setting != null)
				{
					setting.Value = item.GetValue(data, null).ToString();
					await _unitOfWork.SettingsWriteRepository.UpdateAsync(setting);
					await _unitOfWork.SaveAsync();
				}
			}

			return new Response<ProblemDetails>(message: "Güncelleme işlemi başarılı.", success: true);
		}

		public async Task<Response<ProblemDetails>> SaveGeneralSettingsAsync(GeneralSettingUpdateDto data, ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			foreach (var item in data.GetType().GetProperties())
			{
				var setting = await _unitOfWork.SettingsReadRepository.GetAsync(s => s.SettingKey.Equals(item.Name));
				if (setting != null)
				{
					setting.Value = item.GetValue(data, null).ToString();
					await _unitOfWork.SettingsWriteRepository.UpdateAsync(setting);
					await _unitOfWork.SaveAsync();
				}
			}

			return new Response<ProblemDetails>(message: "Güncelleme işlemi başarılı.", success: true);
		}

		public async Task<Response<ProblemDetails>> SaveMailSettingsAsync(EmailSettingUpdateDto data, ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			foreach (var item in data.GetType().GetProperties())
			{
				var setting = await _unitOfWork.SettingsReadRepository.GetAsync(s => s.SettingKey.Equals(item.Name));
				if (setting != null)
				{
					setting.Value = item.GetValue(data, null).ToString();
					await _unitOfWork.SettingsWriteRepository.UpdateAsync(setting);
					await _unitOfWork.SaveAsync();
				}
			}

			return new Response<ProblemDetails>(message: "Güncelleme işlemi başarılı.", success: true);
		}

		public async Task<Response<ProblemDetails>> SavePagingSettingsAsync(PagingSettingUpdateDto data, ModelStateDictionary modelState)
		{
			if (!modelState.IsValid)
			{
				return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));
			}

			foreach (var item in data.GetType().GetProperties())
			{
				var setting = await _unitOfWork.SettingsReadRepository.GetAsync(s => s.SettingKey.Equals(item.Name));
				if (setting != null)
				{
					setting.Value = item.GetValue(data, null).ToString();
					await _unitOfWork.SettingsWriteRepository.UpdateAsync(setting);
					await _unitOfWork.SaveAsync();
				}
			}

			return new Response<ProblemDetails>(message: "Güncelleme işlemi başarılı.", success: true);
		}
		#endregion

		#region Delete

		#endregion
	}
}
