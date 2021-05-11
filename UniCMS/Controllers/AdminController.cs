using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniCMS.Data.Models;
using System.Timers;
using Microsoft.AspNetCore.Authorization;

namespace UniCMS.Controllers
{
  [Authorize]
  public class AdminController : Controller
  {
    ApplicationContext db;
    public AdminController(ApplicationContext context)
    {
      db = context;
    }

    //Главная страница Админ панели
    [AllowAnonymous]
    [HttpGet("Admin")]
    public ActionResult Admin()
    {
      if (User.Identity.IsAuthenticated)
      {
        return View();
      }
      return RedirectToAction("Login", "Login");
    }
    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    //Добавление нового товара в БД
    [HttpPost]
    public IActionResult Create(Product product)
    {
      db.Products.Add(product);
      db.SaveChanges();
      return View();
    }
    public async Task<ActionResult> Update()
    {
      return View(await db.Products.ToListAsync());
    }

    //Изменение товара
    [HttpPost]
    public async Task<ActionResult> Update(Product product)
    {
      db.Products.Update(product);
      db.SaveChanges();
      return View(await db.Products.ToListAsync());
    }

    public async Task<ActionResult> Delete()
    {
      return View(await db.Products.ToListAsync());
    }

    //Удаление товара
    [HttpPost]
    public ActionResult Delete(Product product)
    {
      db.Products.Remove(product);
      db.SaveChanges();
      return View(db.Products.ToList());
    }
    public ActionResult Design()
    {
      return View();
    }

    //Используется для передачи данных в поля "Имя товара", "Описание" и "Цена"
    [HttpGet("UpdateAJAX")]
    public JsonResult UpdateAJAX(string ProductId, int NetId)
    {
      NetId = Convert.ToInt32(ProductId);
      var product1 = db.Products.FirstOrDefault(t => t.Id == NetId);

      return new JsonResult(product1);
    }
  }

}
