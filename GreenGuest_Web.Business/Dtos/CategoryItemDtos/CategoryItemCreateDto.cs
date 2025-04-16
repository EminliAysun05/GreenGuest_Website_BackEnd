using GreenGuest_Web.Business.Abstractions.Dtos;

namespace GreenGuest_Web.Business.Dtos.CategoryItemDtos;

public class CategoryItemCreateDto : IDto
{
	public string Title { get; set; } = null!;
	public string Icon { get; set; } = null!;
	public string ButtonPath { get; set; } = null!;
}
public class CategoryItemUpdateDto : IDto
{
	public int Id { get; set; }
	public string? Title { get; set; }
	public string? Icon { get; set; }
	public string? ButtonPath { get; set; }
}
public class CategoryItemListDto : IDto
{
	public int Id { get; set; }
	public string Title { get; set; } = null!;
	public string Icon { get; set; } = null!;
	public string? ButtonPath { get; set; }
}
