using GreenGuest_Web.Business.Dtos.CategoryItemDtos;
using GreenGuest_Web.Business.Services.Abstractions.Generic;

namespace GreenGuest_Web.Business.Services.Abstractions;

public interface ICategoryItemService : IModifyService<CategoryItemCreateDto, CategoryItemUpdateDto, CategoryItemListDto>
{
}
