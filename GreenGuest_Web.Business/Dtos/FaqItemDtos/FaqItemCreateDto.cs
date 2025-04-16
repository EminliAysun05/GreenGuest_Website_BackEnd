using GreenGuest_Web.Business.Abstractions.Dtos;

namespace GreenGuest_Web.Business.Dtos.FaqItemDtos;

public class FaqItemCreateDto : IDto
{
	public string Question { get; set; } = null!;
	public string Answer { get; set; } = null!;
}
public class FaqItemUpdateDto : IDto
{
	public int Id { get; set; }
	public string? Question { get; set; } 
	public string? Answer { get; set; } 
}
public class FaqItemListDto : IDto
{
	public int Id { get; set; }
	public string Question { get; set; } = null!;
	public string Answer { get; set; } = null!;
}
