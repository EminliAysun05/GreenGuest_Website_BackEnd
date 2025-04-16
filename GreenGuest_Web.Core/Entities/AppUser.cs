using Microsoft.AspNetCore.Identity;

namespace GreenGuest_Web.Core.Entities;

public class AppUser : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
}
