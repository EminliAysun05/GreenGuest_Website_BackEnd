using GreenGuest_Web.Business.Dtos.SliderDtos;
using GreenGuest_Web.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GreenGuest_Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        // 1. Siyahı
        public async Task<IActionResult> Index()
        {
            var sliders = await _sliderService.ListAsync();
            return View(sliders);
        }

        // 2. Create GET
        public IActionResult Create()
        {
            return View();
        }

        // 3. Create POST
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateDto dto)
        {
            var result = await _sliderService.CreateAsync(dto, ModelState);
            if (!result)
                return View(dto);

            return RedirectToAction(nameof(Index));
        }

        // 4. Update GET
        public async Task<IActionResult> Update(int id)
        {
            var dto = await _sliderService.GetUpdatedDtoAsync(id);
            return View(dto);
        }

        // 5. Update POST
        [HttpPost]
        public async Task<IActionResult> Update(SliderUpdateDto dto)
        {
            var result = await _sliderService.UpdateAsync(dto, ModelState);
            if (!result)
                return View(dto);

            return RedirectToAction(nameof(Index));
        }

        // 6. Delete
        public async Task<IActionResult> Delete(int id)
        {
            await _sliderService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

