using GreenGuest_Web.Business.Dtos.CategoryItemDtos;
using GreenGuest_Web.Business.Dtos.FaqItemDtos;
using GreenGuest_Web.Business.Dtos.SettingDtos;
using GreenGuest_Web.Business.Dtos.SliderDtos;

namespace GreenGuest_Web.Areas.Admin.ViewModel
{
    public class HomeVM
    {
        public List<SliderListDto> Sliders { get; set; } = new();
        public List<SettingListDto> Settings { get; set; } = new();
        public List<CategoryItemListDto> Categories { get; set; } = new();
        public List<FaqItemListDto> Faqs { get; set; } = new();
    }
}
