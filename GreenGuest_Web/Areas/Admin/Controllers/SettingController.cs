using GreenGuest_Web.Business.Dtos.SettingDtos;
using GreenGuest_Web.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GreenGuest_Web.Areas.Admin.Controllers;

[Area("Admin")]
public class SettingController : BaseAdminController
{
    private readonly ISettingService _settingService;

    public SettingController(ISettingService settingService)
    {
        _settingService = settingService;
    }

    public async Task<IActionResult> Index()
    {
        var settings = await _settingService.ListAsync();
        return View(settings);
    }
    public IActionResult Create()
    {
        return View();
    }

    // POST: Create
    [HttpPost]
    public async Task<IActionResult> Create(SettingCreateDto dto)
    {
        var result = await _settingService.CreateAsync(dto, ModelState);
        if (!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Update(int id)
    {
        var dto = await _settingService.GetUpdatedDtoAsync(id);
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Update(SettingUpdateDto dto)
    {
        var result = await _settingService.UpdateAsync(dto, ModelState);
        if (!result)
            return View(dto);

        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        await _settingService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}

