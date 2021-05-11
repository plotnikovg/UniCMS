using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniCMS.Data.Models;
using UniCMS.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Timers;

namespace UniCMS.Controllers
{
  public class HomeController : Controller
  {
    ApplicationContext db;
    public HomeController(ApplicationContext context)
    {
      db = context;
    }

    //Главная страница сайта. В метод View передаётся список товаров из БД. 
    public async Task<IActionResult> Index()
    {
      return View(await db.Products.ToListAsync());
    }
  }
}
