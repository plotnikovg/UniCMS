using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UniCMS
{
  public class Program
  {
    //Код, который запускается при запуске приложения
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args) //Создание и установка конфигурации хоста
            .ConfigureWebHostDefaults(webBuilder => 
            {
              webBuilder.UseStartup<Startup>(); //Установка стартового класса приложения
            });
  }
}
