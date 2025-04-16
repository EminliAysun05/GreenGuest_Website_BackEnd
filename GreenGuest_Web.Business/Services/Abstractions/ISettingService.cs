using GreenGuest_Web.Business.Dtos.SettingDtos;
using GreenGuest_Web.Business.Services.Abstractions.Generic;

namespace GreenGuest_Web.Business.Services.Abstractions;

public interface ISettingService : IModifyService<SettingCreateDto, SettingUpdateDto, SettingListDto>
{
	Task<string?> GetValueAsync(string key);
}
