using GreenGuest_Web.Business.Abstractions.Dtos;
using Microsoft.AspNetCore.Http;

namespace GreenGuest_Web.Business.Dtos.SliderDtos;

public class SliderCreateDto : IDto
{
	public string Title { get; set; } = null!;
	public string? Description { get; set; }
	public IFormFile Image { get; set; } = null!;
	public string? ButtonPath { get; set; }
}
public class SliderUpdateDto : IDto
{
	public int Id { get; set; }
	public string? Title { get; set; } 
	public string? Description { get; set; }
	public IFormFile? Image { get; set; } = null!;
	public string? ImagePath { get; set; } 
	public string? ButtonPath { get; set; }
}
public class SliderListDto : IDto
{
	public int Id { get; set; }
	public string Title { get; set; } = null!;
	public string? Description { get; set; }
	public string ImagePath { get; set; } = null!;
	public string? ButtonPath { get; set; }
}
