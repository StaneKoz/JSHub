using Microsoft.AspNetCore.Mvc;
using Portfolio.Service.Interfaces;

namespace Portfolio.Controllers
{
    public class SpecialityController : Controller
    {
        private readonly ISpecialityBox _specialityService;

        public SpecialityController(ISpecialityBox specialityService)
        {
            _specialityService = specialityService;
        }
    }
}
