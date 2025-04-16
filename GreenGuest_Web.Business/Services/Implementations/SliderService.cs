using AutoMapper;
using GreenGuest_Web.Business.Dtos.SliderDtos;
using GreenGuest_Web.Business.Extensions;
using GreenGuest_Web.Business.Services.Abstractions;
using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Repositories.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace GreenGuest_Web.Business.Services.Implementations;

public class SliderService : ISliderService
{
	private readonly ISliderRepository _sliderRepository;
	private readonly IMapper _mapper;
	private readonly ICloudinaryService _cloudinaryService;

	public SliderService(ISliderRepository sliderRepository, IMapper mapper, ICloudinaryService cloudinaryService)
	{
		_sliderRepository = sliderRepository;
		_mapper = mapper;
		_cloudinaryService = cloudinaryService;
	}

	public async Task<bool> CreateAsync(SliderCreateDto dto, ModelStateDictionary ModelState)
	{
		if (!ModelState.IsValid)
			return false;

		if (dto.Image.ValidateType())
		{
			ModelState.AddModelError("Image", "Şəkil formatı düzgün deyil.");
			return false;
		}

		if (dto.Image.ValidateSize(2))
		{
			ModelState.AddModelError("Image", "Şəkil ölçüsü 2MB-dan böyükdür.");
			return false;
		}

		var imageUrl = await _cloudinaryService.FileCreateAsync(dto.Image);
		var entity = _mapper.Map<Slider>(dto);
		entity.ImagePath = imageUrl;

		await _sliderRepository.CreateAsync(entity);
		await _sliderRepository.SaveChangesAsync();
		return true;

	}

	public async Task DeleteAsync(int id)
	{
		var entity = await _sliderRepository.GetByIdAsync(id);
		if(entity is not null)
		{
			await _cloudinaryService.FileDeleteAsync(entity.ImagePath);
			_sliderRepository.Delete(entity);
			await _sliderRepository.SaveChangesAsync();
		}
	}

	public Task<SliderUpdateDto> GetUpdatedDtoAsync(int id)
	{
		throw new NotImplementedException();
	}

	public async Task<List<SliderListDto>> ListAsync()
	{
		var entities = await _sliderRepository.GetAll().ToListAsync();
		return _mapper.Map<List<SliderListDto>>(entities);
	}

	public async Task<bool> UpdateAsync(SliderUpdateDto dto, ModelStateDictionary ModelState)
	{
		if (!ModelState.IsValid)
			return false;

		var entity = await _sliderRepository.GetByIdAsync(dto.Id);
		if (entity == null)
		{
			ModelState.AddModelError("", "Slider tapılmadı.");
			return false;
		}

		if (dto.Image is not null)
		{
			if (!dto.Image.ValidateType())
			{
				ModelState.AddModelError("Image", "Şəkil formatı düzgün deyil.");
				return false;
			}

			if (!dto.Image.ValidateSize(2))
			{
				ModelState.AddModelError("Image", "Şəkil ölçüsü maksimum 2MB olmalıdır.");
				return false;
			}

			await _cloudinaryService.FileDeleteAsync(entity.ImagePath);
			var imageUrl = await _cloudinaryService.FileCreateAsync(dto.Image);
			entity.ImagePath = imageUrl;
		}

		_mapper.Map(dto, entity);

		_sliderRepository.Update(entity);
		await _sliderRepository.SaveChangesAsync();

		return true;
	}
}
	

