
using JSHub.Dal;
using JSHub.Domain.Entity;
using JSHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics;

namespace JSHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DbContextOptions<AppDBContext> options;

        public HomeController(ILogger<HomeController> logger, DbContextOptions<AppDBContext> options)
        {
            this.options = options;
        }

        public IActionResult Index()
        {
    /*        using (var db = new AppDBContext(options))
            {
                var user = new User { Email = "sas@mail.ru", Password = "123" };
                db.Users.Add(user);
                db.SaveChanges();
            }*/
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}