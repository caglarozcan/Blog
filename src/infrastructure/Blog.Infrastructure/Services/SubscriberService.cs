using Blog.Application.Dto.SubscriberDto;
using Blog.Application.Enums;
using Blog.Application.Request;
using Blog.Application.Response;
using Blog.Application.Services;
using Blog.Application.UnitOfWork;

namespace Blog.Infrastructure.Services;

public class SubscriberService : BaseService, ISubscriberService
{
	private readonly IUnitOfWork _unitOfWork;

	public SubscriberService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	#region Functions
	#region Create

	#endregion

	#region Read
	public async ValueTask<PagingDataResponse<SubscriberListDto>> GetSubscriberListAsync(DataListRequest request)
	{
		return await _unitOfWork.SubscriberReadRepository.GetSubscriberListAsync(request);
	}
	#endregion

	#region Update
	public async ValueTask<Response> StatusChangeAsync(Guid id)
	{
		bool subscriberExists = await _unitOfWork.SubscriberReadRepository.AnyAsync(a => a.Id.Equals(id));

		if (!subscriberExists)
			return new Response("İşlem yapmak istediğiniz abone sistemde bulunamadı.", false);

		var subscriber = await _unitOfWork.SubscriberReadRepository.GetAsync(c => c.Id.Equals(id));
		subscriber.Status = (byte)(subscriber.Status == 1 ? Status.Passive : Status.Active);
		await _unitOfWork.SubscriberWriteRepository.UpdateAsync(subscriber);

		int result = await _unitOfWork.SaveAsync();

		if (!result.Equals(1))
			return new Response("Abone durumu değiştirme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", false);

		return new Response("Abone durumu değiştirilmiştir.", true);
	}
	#endregion

	#region Delete
	public async ValueTask<Response> DeleteAsync(Guid id)
	{
		bool subscriberExists = await _unitOfWork.SubscriberReadRepository.AnyAsync(a => a.Id.Equals(id));

		if (!subscriberExists)
			return new Response("İşlem yapmak istediğiniz abone sistemde bulunamadı.", false);

		var subscriber = await _unitOfWork.SubscriberReadRepository.GetAsync(c => c.Id.Equals(id));

		await _unitOfWork.SubscriberWriteRepository.DeleteAsync(subscriber);

		int result = await _unitOfWork.SaveAsync();

		if (!result.Equals(1))
			return new Response("Abone silme sırasında bir hata oluştu. Daha sonra tekrar deneyiniz.", false);

		return new Response("Abone başarıyla silinmiştir.", true);
	}
	#endregion
	#endregion
}
