using AutoMapper;
using GreenGuest_Web.Business.Dtos.SliderDtos;
using GreenGuest_Web.Core.Entities;

namespace GreenGuest_Web.Business.AutoMappers;

public class SliderAutoMapper : Profile
{
        public SliderAutoMapper()
        {
		// 1. CreateDto → Entity
		CreateMap<SliderCreateDto, Slider>()
			.ForMember(dest => dest.ImagePath, opt => opt.Ignore()); // Image faylı controller/service-də işlənəcək

		// 2. UpdateDto → Entity (yalnız null olmayan sahələri mapp edir)
		CreateMap<SliderUpdateDto, Slider>()
			.ForAllMembers(opt =>
				opt.Condition((src, dest, srcMember) => srcMember != null));

		// 3. Entity → ListDto
		CreateMap<Slider, SliderListDto>();
	}
    }
