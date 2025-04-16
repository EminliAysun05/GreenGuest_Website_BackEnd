using GreenGuest_Web.Business.Abstractions.Dtos;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GreenGuest_Web.Business.Services.Abstractions.Generic
{
	public interface IModifyService<TCreateDto, TUpdateDto, TListDto>
	where TCreateDto : IDto
	where TUpdateDto : IDto
	where TListDto : IDto

	{
		Task<bool> CreateAsync(TCreateDto dto, ModelStateDictionary ModelState);
		Task<bool> UpdateAsync(TUpdateDto dto, ModelStateDictionary ModelState);
		Task<TUpdateDto> GetUpdatedDtoAsync(int id);
		Task DeleteAsync(int id);
		Task<List<TListDto>> ListAsync();
	}
}
