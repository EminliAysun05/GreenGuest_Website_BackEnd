using AutoMapper;
using GreenGuest_Web.Business.Dtos.FaqItemDtos;
using GreenGuest_Web.Core.Entities;

namespace GreenGuest_Web.Business.AutoMappers;

	public class FaqItemAutoMapper : Profile
	{
    public FaqItemAutoMapper()
    {
		// 1. CreateDto → Entity
		CreateMap<FaqItemCreateDto, FaqItem>();

		// 2. UpdateDto → Entity (yalnız null olmayan sahələri map et)
		CreateMap<FaqItemUpdateDto, FaqItem>()
			.ForAllMembers(opt =>
				opt.Condition((src, dest, srcMember) => srcMember != null));

		// 3. Entity → ListDto
		CreateMap<FaqItem, FaqItemListDto>();
	}
}
