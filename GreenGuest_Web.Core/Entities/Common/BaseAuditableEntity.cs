using GreenGuest_Web.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.Core.Entities.Common
{
	public class BaseAuditableEntity : BaseEntity
	{
		public string CreatedBy { get; set; } = null!;
		public string UpdatedBy { get; set; } = null!;
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
		public bool IsDeleted { get; set; } = false;
		public int ViewCount { get; set; }
	}
}
