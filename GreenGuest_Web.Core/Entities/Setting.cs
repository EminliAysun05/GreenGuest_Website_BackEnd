using GreenGuest_Web.Core.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.Core.Entities
{
	public class Setting : BaseEntity
	{
		public string Key { get; set; } = null!;
		public string Value { get; set; } = null!;	
	}
}
