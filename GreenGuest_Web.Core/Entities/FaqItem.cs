using GreenGuest_Web.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.Core.Entities
{
	public class FaqItem : BaseEntity
	{
		public string Question { get; set; } = null!;
		public string Answer { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
    }
}
