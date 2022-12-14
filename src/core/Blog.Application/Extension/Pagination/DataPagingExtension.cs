using Blog.Application.Response;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Extension.Pagination;

public static class DataPagingExtension
{
    public static async Task<PagingDataResponse<T>> ToPagingData<T>(this IQueryable<T> source, int? perData, int? page) 
        where T : class
    {
        page = page ?? 1;
        perData = perData ?? 15;

        PagingDataResponse<T> response = new();
        response.TotalRow = source.Count();
        response.CurrentPage = page.Value;
        response.Data = await source.Skip((page.Value - 1) * perData.Value).Take(perData.Value).ToListAsync().ConfigureAwait(false);
        return response;
    }
}
