using GreenGuest_Web.Business.Dtos.CategoryItemDtos;
using GreenGuest_Web.Business.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenGuest_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class CategoryController : BaseAdminController
    {
        private readonly ICategoryItemService _categoryItemService;

        public CategoryController(ICategoryItemService categoryItemService)
        {
            _categoryItemService = categoryItemService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryItemService.ListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryItemCreateDto dto)
        {
            var result = await _categoryItemService.CreateAsync(dto, ModelState);
            if (!result) return View(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var dto = await _categoryItemService.GetUpdatedDtoAsync(id);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CategoryItemUpdateDto dto)
        {
            var result = await _categoryItemService.UpdateAsync(dto, ModelState);
            if (!result) return View(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryItemService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
