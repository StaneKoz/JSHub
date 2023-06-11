using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
