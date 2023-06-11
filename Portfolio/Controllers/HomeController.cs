
using Portfolio.Dal;
using Portfolio.Dal.Interfaces;
using Portfolio.Domain.Entity;
using Portfolio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Portfolio.Controllers
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
        
        public IActionResult GetFiles()
        {
            return View();
        }

        public IActionResult GetStatusCode()
        {
            return BadRequest();  
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