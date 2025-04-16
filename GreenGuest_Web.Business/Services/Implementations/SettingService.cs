using AutoMapper;
using GreenGuest_Web.Business.Dtos.SettingDtos;
using GreenGuest_Web.Business.Exceptions;
using GreenGuest_Web.Business.Services.Abstractions;
using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GreenGuest_Web.Business.Services.Implementations;

public class SettingService : ISettingService
{
	private readonly ISettingRepository _settingRepository;
	private readonly IMapper _mapper;

	public SettingService(ISettingRepository settingRepository, IMapper mapper)
	{
		_settingRepository = settingRepository;
		_mapper = mapper;
	}

	public async Task<bool> CreateAsync(SettingCreateDto dto, ModelStateDictionary modelState)
	{
		if (!modelState.IsValid)
			return false;
		
		var entity = _mapper.Map<Setting>(dto);
		await _settingRepository.CreateAsync(entity);
		await _settingRepository.SaveChangesAsync();
		return true;
	}

	public async Task DeleteAsync(int id)
	{
		var entity = await _settingRepository.GetByIdAsync(id);
		if(entity is not null)
		{
			_settingRepository.Delete(entity);
			await _settingRepository.SaveChangesAsync();
		}
	}

	public async Task<SettingUpdateDto> GetUpdatedDtoAsync(int id)
	{
		var entity = await _settingRepository.GetByIdAsync(id);
		if (entity is null)
			throw new NotFoundException("Setting not found");

		var dto = _mapper.Map<SettingUpdateDto>(entity);
		return dto;
	}

	public async Task<List<SettingListDto>> ListAsync()
	{
		var entites = await _settingRepository.GetAll().ToListAsync();
		var dtos = _mapper.Map<List<SettingListDto>>(entites);
		return dtos;

	}

	public async Task<bool> UpdateAsync(SettingUpdateDto dto, ModelStateDictionary ModelState)
	{
		if (!ModelState.IsValid)
			return false; 
		
		var entity =  await _settingRepository.GetByIdAsync(dto.Id);
		if(entity is null)
		{
			ModelState.AddModelError("Id", "Setting not found");
			return false;
		}

		_mapper.Map(dto, entity);
		_settingRepository.Update(entity);
		 await _settingRepository.SaveChangesAsync();

		return true;
	}

	public async Task<string?> GetValueAsync(string key)
	{
		var setting = await _settingRepository.GetSingleAsync(x => x.Key == key);
		return setting?.Value;
	}
}
