using GreenGuest_Web.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.Core.Entities
{
	public class Slider : BaseEntity
	{
		public string Title { get; set; } = null!;
		public string? Description { get; set; } 
		public string ImagePath { get; set; } = null!;
		public string? ButtonPath { get; set; }

	}
}
