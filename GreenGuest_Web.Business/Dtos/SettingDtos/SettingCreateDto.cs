using GreenGuest_Web.Business.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.Business.Dtos.SettingDtos
{
	public class SettingCreateDto : IDto
	{
		public string Key { get; set; } = null!;
		public string Value { get; set; } = null!;
	}
	public class SettingUpdateDto : IDto
	{
		public int Id { get; set; }
		public string? Key { get; set; }
		public string Value { get; set; } = null!;
	}
	public class SettingListDto : IDto
	{
		public int Id { get; set; }
		public string Key { get; set; } = null!;
		public string Value { get; set; } = null!;
	}
}
