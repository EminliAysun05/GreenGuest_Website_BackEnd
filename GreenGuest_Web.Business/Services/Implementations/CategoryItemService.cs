using AutoMapper;
using GreenGuest_Web.Business.Dtos.CategoryItemDtos;
using GreenGuest_Web.Business.Exceptions;
using GreenGuest_Web.Business.Services.Abstractions;
using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GreenGuest_Web.Business.Services.Implementations;

public class CategoryItemService : ICategoryItemService
{
	private readonly ICategoryItemRepository _categoryItemRepository;
	private readonly IMapper _mapper;

	public CategoryItemService(ICategoryItemRepository categoryItemRepository, IMapper mapper)
	{
		_categoryItemRepository = categoryItemRepository;
		_mapper = mapper;
	}

	public async Task<bool> CreateAsync(CategoryItemCreateDto dto, ModelStateDictionary ModelState)
	{
		if(!ModelState.IsValid)
			return false;

		var entity = _mapper.Map<CategoryItem>(dto);
		await _categoryItemRepository.CreateAsync(entity);
		await _categoryItemRepository.SaveChangesAsync();
		return true;

	}

	public async Task DeleteAsync(int id)
	{
		var entity = await _categoryItemRepository.GetByIdAsync(id);
		if (entity != null)
		{
			_categoryItemRepository.Delete(entity);
			await _categoryItemRepository.SaveChangesAsync();
		}
	}



	public async Task<CategoryItemUpdateDto> GetUpdatedDtoAsync(int id)
	{
		var entity = await _categoryItemRepository.GetByIdAsync(id);
		if(entity == null)
			throw new NotFoundException("CategoryItem not found");

		var dto = _mapper.Map<CategoryItemUpdateDto>(entity);
		return dto;
	}

	public async Task<List<CategoryItemListDto>> ListAsync()
	{
		var entity = await _categoryItemRepository.GetAll().ToListAsync();
		var dtos = _mapper.Map<List<CategoryItemListDto>>(entity);
		return dtos;

	}

	public async Task<bool> UpdateAsync(CategoryItemUpdateDto dto, ModelStateDictionary ModelState)
	{
		if(!ModelState.IsValid)
			return false;

		var entity = await _categoryItemRepository.GetByIdAsync(dto.Id);
		if(entity == null)
		{
			ModelState.AddModelError("Id", "CategoryItem not found");
			return false;
		}

		_mapper.Map(dto, entity);
		_categoryItemRepository.Update(entity);
		await _categoryItemRepository.SaveChangesAsync();

		return true;
	}
}
