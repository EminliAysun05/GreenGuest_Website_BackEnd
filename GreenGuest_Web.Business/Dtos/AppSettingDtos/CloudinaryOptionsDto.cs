using GreenGuest_Web.Business.Abstractions.Dtos;

namespace GreenGuest_Web.Business.Dtos.AppSettingDtos;

public class CloudinaryOptionsDto : IDto
{
	public string APIKey { get; set; } = null!;
	public string APISecret { get; set; } = null!;
	public string CloudName { get; set; } = null!;
}
