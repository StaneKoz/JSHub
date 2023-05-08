
using JSHub.Dal;
using JSHub.Dal.Interfaces;
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
        private readonly IBaseRepository<User> _userRepository;

        public HomeController(IBaseRepository<User> userRepository, ILogger<HomeController> logger, DbContextOptions<AppDBContext> options)
        {
            this.options = options;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BadRequest() => View();
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}