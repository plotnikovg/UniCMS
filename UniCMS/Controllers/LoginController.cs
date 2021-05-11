using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniCMS.Data.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace UniCMS.Controllers
{
  public class LoginController : Controller
  {
    private ApplicationContext db;
    public LoginController(ApplicationContext context)
    {
      db = context;
    }
    [HttpGet("Login")]
    public ActionResult Login()
    {
      return View();
    }
    private async Task Authenticate(string UserName)
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimsIdentity.DefaultNameClaimType, UserName)
      };
      ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
      await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
    }

    //Это действие вызывается при отправке формы нажатием "Enter"
    [HttpPost]
    public async Task<ActionResult> EnterLogin(string UserName, string Password)
    {
      User rightUser = await db.Users.FirstOrDefaultAsync(t => t.UserName == UserName && t.Password == Password);
      if (rightUser != null)
      {
        await Authenticate(rightUser.UserName);
        return RedirectToAction("Admin","Admin");
      }
      return RedirectToAction("Login", "Login");
    }

    //Это действие вызывается AJAX запросами при изменении полей ввода 
    [HttpPost("Login")]
    public async Task<JsonResult> Login(string UserName, string Password)
    {
      User rightUser = await db.Users.FirstOrDefaultAsync(t => t.UserName == UserName && t.Password == Password);
      if (rightUser != null)
      {
        await Authenticate(rightUser.UserName);
        return Json(new { returnvalue = true });
      }
      return Json(new { returnvalue = false });
    }

  }
}
