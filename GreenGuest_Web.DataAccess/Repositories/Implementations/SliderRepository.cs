using GreenGuest_Web.Core.Entities;
using GreenGuest_Web.DataAccess.Contexts;
using GreenGuest_Web.DataAccess.Repositories.Abstractions;
using GreenGuest_Web.DataAccess.Repositories.Abstractions.Generic;
using GreenGuest_Web.DataAccess.Repositories.Implementations.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.DataAccess.Repositories.Implementations
{
	internal class SliderRepository : Repository<Slider>, ISliderRepository
	{
		public SliderRepository(AppDbContext context) : base(context)
		{
		}
	}
}
