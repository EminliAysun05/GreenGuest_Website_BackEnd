using GreenGuest_Web.Business.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenGuest_Web.Business.Dtos.AppUserDtos
{
	public class LoginDto : IDto
	{
		public string Username { get; set; } = null!;
		public string Password { get; set; } = null!;
	}
}
