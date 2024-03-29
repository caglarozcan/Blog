﻿using Blog.Application.Dto.CategoryDto;
using Blog.Application.Enums;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Infrastructure.Services;

public class CategoryService : BaseService, ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITextService _textService;

    public CategoryService(IUnitOfWork unitOfWork, 
        ITextService textService)
    {
        this._unitOfWork = unitOfWork;
        _textService = textService;
    }

    #region Create
    public async ValueTask<Response<ProblemDetails>> InsertAsync(CategoryInsertDto data, ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
            return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));

        if (String.IsNullOrWhiteSpace(data.Slug))
            data.Slug = _textService.Slug(data.Title);

        if (await _unitOfWork.CategoryReadRepository.AnyAsync(c => c.Slug.Equals(data.Slug.Trim())))
            return new Response<ProblemDetails>(message: "Aynı isimde kategori sistemde tanımlı. Farklı bir isim giriniz.", success: false);

        await _unitOfWork.CategoryWriteRepository.InsertAsync(new Domain.Entities.Category()
        {
            Title = data.Title.Trim(),
            Icon = data.Icon.Trim(),
            Slug = data.Slug.Trim(),
            Color = data.Color.Trim(),
            ParentId = data.ParentId,
            Status = data.Status,
            Description = data.Description.Trim()
        });

        int result = await _unitOfWork.SaveAsync();

        if (result != 1)
            return new Response<ProblemDetails>(message: "Kategori ekleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);

        return new Response<ProblemDetails>(message: "Kategori başarıyla eklendi.", success: true);
    }
    #endregion

    #region Read
    public async ValueTask<PagingDataResponse<CategoryListDto>> GetCategoryListAsync(DataListRequest request)
    {
        var categoryList = await _unitOfWork.CategoryReadRepository.GetCategoryListAsync(request);

        return categoryList;
    }

    public async ValueTask<Response<CategoryListDto>> GetUpdatedCategoryInfoAsync(Guid id)
    {
        var category = await _unitOfWork.CategoryReadRepository.GetAsync(c => c.Id.Equals(id));

        if (category is null)
            return new Response<CategoryListDto>("İşlem yapmak istediğiniz kategori sistemde bulunamadı.", false);

        return new Response<CategoryListDto>("Kategori bilgileri.", true, new CategoryListDto()
        {
            Icon = category.Icon,
            Id = category.Id,
            Description = category.Description,
            Color = category.Color,
            CreatedDate = category.CreatedDate,
            ParentId = category.ParentId,
            Slug = category.Slug,
            Status = category.Status,
            Title = category.Title
        });
    }

    public async ValueTask<CategorySelectDto> GetSelectCategoriesAsync(Guid? id)
    {
        return await _unitOfWork.CategoryReadRepository.GetCategorySelect(id);
    }

    public async ValueTask<List<HierarchicalCategoryListDto>> GetHierarchicalCategoryListsync()
    {
        var query = await _unitOfWork.CategoryReadRepository.GetAllAsync(c => !c.ParentId.HasValue, includes: i => i.Childs);

        return query.Select(s => new HierarchicalCategoryListDto()
        {
            Id = s.Id,
            Title = s.Title,
            Icon = s.Icon,
            Color = s.Color,
            Description = s.Description,
            Slug = s.Slug,
            ChildCategories = s.Childs.Select(c => new CategoryListDto()
            {
                Id = c.Id,
                Title = c.Title,
                Icon = c.Icon,
                Color = c.Color,
                Description = c.Description,
                Slug = c.Slug
            }).ToList()
        }).ToList();
    }
    #endregion

    #region Update
    public async ValueTask<Response<ProblemDetails>> EditAsync(CategoryEditDto data, ModelStateDictionary modelState)
    {
        if (!modelState.IsValid)
            return new Response<ProblemDetails>(message: "Doğrulama hatası", success: false, ModelValidationProblem(modelState, "Formda gönderilen alanlar geçersiz veya eksik."));

        if (String.IsNullOrWhiteSpace(data.Slug))
            data.Slug = _textService.Slug(data.Title);

        if (await _unitOfWork.CategoryReadRepository.AnyAsync(c => !c.Id.Equals(data.Id) && (c.Title.Equals(data.Title.Trim()) || c.Slug.Equals(data.Slug.Trim()))))
        {
            return new Response<ProblemDetails>(message: "Aynı isimde kategori sistemde tanımlı. Farklı bir isim giriniz.", success: false);
        }
        else
        {
            var category = await _unitOfWork.CategoryReadRepository.GetAsync(c => c.Id.Equals(data.Id));

            if (category is null)
                return new Response<ProblemDetails>(message: "Güncellemek istediğiniz kategori sistemde bulunamadı.", success: false);

            category.Color = data.Color.Trim();
            category.Description = data.Description.Trim();
            category.Icon = data.Icon.Trim();
            category.ParentId = data.ParentId;
            category.Title = data.Title.Trim();
            category.UpdatedDate = DateTime.Now;
            category.Slug = data.Slug.Trim();
            category.Status = data.Status;

            await _unitOfWork.CategoryWriteRepository.UpdateAsync(category);

            int result = await _unitOfWork.SaveAsync();

            if (result != 1)
                return new Response<ProblemDetails>(message: "Kategori güncelleme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", success: false);
        }

        return new Response<ProblemDetails>(message: "Kategori başarıyla güncellendi.", success: true);
    }

    public async ValueTask<Response> StatusChangeAsync(Guid id)
    {
        var category = await _unitOfWork.CategoryReadRepository.GetAsync(c => c.Id.Equals(id));

        if (category is null)
            return new Response("İşlem yapmak istediğiniz kategori sistemde bulunamadı.", false);

        category.Status = (byte)(category.Status == 1 ? Status.Passive : Status.Active);
        await _unitOfWork.CategoryWriteRepository.UpdateAsync(category);

        int result = await _unitOfWork.SaveAsync();

        if (result != 1)
            return new Response("Kategori durumu değiştirme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", false);

        return new Response("Kategori durumu değiştirilmiştir.", true);
    }
    #endregion

    #region Delete
    public async ValueTask<Response> DeleteAsync(Guid id)
    {
        var category = await _unitOfWork.CategoryReadRepository.GetAsync(c => c.Id.Equals(id));

        if (category is null)
            return new Response("İşlem yapmak istediğiniz kategori sistemde bulunamadı.", false);

        await _unitOfWork.CategoryWriteRepository.DeleteAsync(category);

        int result = await _unitOfWork.SaveAsync();

        if (result != 1)
            return new Response("Kategori silme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", false);

        return new Response("Kategori başarıyla silinmiştir.", true);
    }
    #endregion
}
