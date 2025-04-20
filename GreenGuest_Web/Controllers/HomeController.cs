using GreenGuest_Web.Areas.Admin.ViewModel;
using GreenGuest_Web.Business.Services.Abstractions;
using GreenGuest_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GreenGuest_Web.Controllers
{
        public class HomeController : Controller
        {
            private readonly ISliderService _sliderService;
            private readonly ISettingService _settingService;
            private readonly ICategoryItemService _categoryItemService;
            private readonly IFaqItemService _faqItemService;

            public HomeController(
                ISliderService sliderService,
                ISettingService settingService,
                ICategoryItemService categoryItemService,
                IFaqItemService faqItemService)
            {
                _sliderService = sliderService;
                _settingService = settingService;
                _categoryItemService = categoryItemService;
                _faqItemService = faqItemService;
            }

            public async Task<IActionResult> Index()
            {
                var sliders = await _sliderService.ListAsync();
                var settings = await _settingService.ListAsync();
                var categories = await _categoryItemService.ListAsync();
                var faqs = await _faqItemService.ListAsync();

                var vm = new HomeVM
                {
                    Sliders = sliders,
                    Settings = settings,
                    Categories = categories,
                    Faqs = faqs
                };

                return View(vm);
            }
        }
    }
