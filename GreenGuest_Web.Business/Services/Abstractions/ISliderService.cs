using GreenGuest_Web.Business.Dtos.SliderDtos;
using GreenGuest_Web.Business.Services.Abstractions.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.Business.Services.Abstractions
{
	public interface ISliderService : IModifyService<SliderCreateDto, SliderUpdateDto, SliderListDto>
	{
	}
}
