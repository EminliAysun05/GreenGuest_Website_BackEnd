using AutoMapper;
using GreenGuest_Web.Business.Dtos.FaqItemDtos;
using GreenGuest_Web.Business.Exceptions;
using GreenGuest_Web.Business.Services.Abstractions;
using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GreenGuest_Web.Business.Services.Implementations;

public class FaqItemService : IFaqItemService
{
	private readonly IFaqItemRepository _faqItemRepository;
	private readonly IMapper _mapper;

	public FaqItemService(IFaqItemRepository faqItemRepository, IMapper mapper)
	{
		_faqItemRepository = faqItemRepository;
		_mapper = mapper;
	}

	public async Task<bool> CreateAsync(FaqItemCreateDto dto, ModelStateDictionary ModelState)
	{
		if (!ModelState.IsValid)
			return false;

		var entity = _mapper.Map<FaqItem>(dto);	
		await _faqItemRepository.CreateAsync(entity);
		await _faqItemRepository.SaveChangesAsync();
		return true;
	}

	public async Task DeleteAsync(int id)
	{
		var entity = await _faqItemRepository.GetByIdAsync(id);
		if(entity !=null)
		{
			_faqItemRepository.Delete(entity);
			await _faqItemRepository.SaveChangesAsync();
		}

	}

	public async Task<FaqItemUpdateDto> GetUpdatedDtoAsync(int id)
	{
		var entity = await _faqItemRepository.GetByIdAsync(id);
		if (entity == null)
			throw new NotFoundException("FaqItem not found");

		var dto = _mapper.Map<FaqItemUpdateDto>(entity);
		return dto;
	}

	public async Task<List<FaqItemListDto>> ListAsync()
	{
		var entity = await _faqItemRepository.GetAll().ToListAsync();
		var dtos = _mapper.Map<List<FaqItemListDto>>(entity);
		return dtos;

	}

	public async Task<bool> UpdateAsync(FaqItemUpdateDto dto, ModelStateDictionary ModelState)
	{
		if(!ModelState.IsValid)
			return false;

		var entity = await _faqItemRepository.GetByIdAsync(dto.Id);

		if(entity ==null)
		{
			ModelState.AddModelError("Id", "Faq item is not found");
			return false;
		}

		_mapper.Map(entity, dto);
		_faqItemRepository.Update(entity);
		await _faqItemRepository.SaveChangesAsync();
		return true;

	}
}
