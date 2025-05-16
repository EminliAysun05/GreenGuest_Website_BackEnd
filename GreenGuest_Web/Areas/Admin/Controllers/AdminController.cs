using GreenGuest_Web.Business.Dtos.AppUserDtos;
using Microsoft.AspNetCore.Mvc;
using GreenGuest_Web.Core.Entities;
[Area("Admin")]
public class AdminController : Controller
{
  
    private readonly AdminCredentials _admin;

    public AdminController(IConfiguration config)
    {
        _admin = config.GetSection("AdminCredentials").Get<AdminCredentials>();
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(AdminLoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        if (model.Username == _admin.Username && model.Password == _admin.Password)
        {
            HttpContext.Session.SetString("IsAdmin", "true");
            return RedirectToAction("Index", "Dashboard");
        }

        ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır.");
        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
