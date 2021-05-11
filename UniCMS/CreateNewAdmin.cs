using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniCMS.Data.Models;

namespace UniCMS
{
  public class CreateNewAdmin
  {
    public static void NewAdmin(ApplicationContext context)
    {
      if (!context.Users.Any())
      {
        context.Users.Add(new User
        {
          UserName = "admin",
          Password = "12345"
        });
        context.SaveChanges();
      }
    }
  }
}
