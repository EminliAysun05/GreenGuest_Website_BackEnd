using AutoMapper;
using GreenGuest_Web.Business.Dtos.CategoryItemDtos;
using GreenGuest_Web.Core.Entities;

namespace GreenGuest_Web.Business.AutoMappers;

public class CategoryItemAutoMapper : Profile
{
    public CategoryItemAutoMapper()
    {
        // 1. CreateDto → Entity
        CreateMap<CategoryItemCreateDto, CategoryItem>();

        // 2. UpdateDto → Entity (null olmayan sahələr mapp olunur)
        CreateMap<CategoryItemUpdateDto, CategoryItem>()
            .ForAllMembers(opt =>
                opt.Condition((src, dest, srcMember) => srcMember != null));

        // 3. Entity → ListDto
        CreateMap<CategoryItem, CategoryItemListDto>();

        // 4. Entity → UpdateDto 
        CreateMap<CategoryItem, CategoryItemUpdateDto>();
    }
}
