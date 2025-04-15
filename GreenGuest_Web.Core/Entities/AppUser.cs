using Microsoft.AspNetCore.Identity;

namespace GreenGuest_Web.Core.Entities;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = null!;
}
