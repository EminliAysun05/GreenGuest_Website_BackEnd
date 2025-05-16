
using GreenGuest_Web.Business.Dtos.FaqItemDtos;
using GreenGuest_Web.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace GreenGuest_Web.Areas.Admin.Controllers;

    [Area("Admin")]
    public class FaqItemController : BaseAdminController
{
        private readonly IFaqItemService _faqItemService;

        public FaqItemController(IFaqItemService faqItemService)
        {
            _faqItemService = faqItemService;
        }

        
        public async Task<IActionResult> Index()
        {
            var faqs = await _faqItemService.ListAsync();
            return View(faqs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FaqItemCreateDto dto)
        {
            var result = await _faqItemService.CreateAsync(dto, ModelState);
            if (!result)
                return View(dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            var dto = await _faqItemService.GetUpdatedDtoAsync(id);
            return View(dto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FaqItemUpdateDto dto)
        {
            var result = await _faqItemService.UpdateAsync(dto, ModelState);
            if (!result)
                return View(dto);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _faqItemService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }



