using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeddingMert.Entity.Concrete;
using WeddingMert.Web.Models;

namespace WeddingMert.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        [Route("girisyap/")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("girisyap/")]
        public async Task<IActionResult> Index(LoginUserViewModel p)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, true, true);
                if (result.Succeeded)
                {
                    //return RedirectToAction("AdresListesi", "AdminAddress");
                    return RedirectToAction("Index", "About", new { Area = "Admin" });

                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre");
                }
            }
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login", new { Area = "Admin" });
        }
    }
}
