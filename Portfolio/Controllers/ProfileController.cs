
using Azure;
using Portfolio.Domain.ViewModels.Profile;
using Portfolio.Service.Implementations;
using Portfolio.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Domain.Entity;

namespace Portfolio.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        IWebHostEnvironment _webHostEnvironment;

        public ProfileController(IProfileService profileService, IWebHostEnvironment webHostEnvironment)
        {
            _profileService = profileService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _profileService.CreateProfile(model, long.Parse(User.Identity.Name));
                if (response.StatusCode == Domain.Enum.StatusCode.OK) return RedirectToAction("Detail", "Profile");
                else
                    ModelState.AddModelError("", response.Description);
            }
            return View(model);
        }

        public IActionResult Detail() // Хочу айди
        {
            var response = _profileService.GetProfile(long.Parse(User.Identity.Name));
            if (response.StatusCode == Portfolio.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            else if (response.StatusCode == Portfolio.Domain.Enum.StatusCode.ProfileNotFound)
            {
                return RedirectToAction("Create", "Profile");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update()
        {
            var profile = _profileService.GetProfile(long.Parse(User.Identity.Name));
            if (profile != null)
            {
                return View(profile.Data);
            }
            return RedirectToAction("Create", "Profile");
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Логика не в том месте
                if (model.AvatarFile != null)
                {
                    string path = String.Format(@"/Files/{0}/Avatar/", User.Identity.Name);
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + path))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + path);
                    }
                    using (var filestream = new FileStream(_webHostEnvironment.WebRootPath + path + model.AvatarFile.FileName, FileMode.Create))
                    {
                        await model.AvatarFile.CopyToAsync(filestream);
                    }
                    Image file = new Image() { Name = model.AvatarFile.FileName, Path = path + model.AvatarFile.FileName };
                    model.Avatar = file;
                }

                var response = _profileService.UpdateProfile(model, long.Parse(User.Identity.Name));
                if (response.StatusCode == Portfolio.Domain.Enum.StatusCode.OK)
                {
                    ViewBag.Status = "Изменения сохранены";
                    return View(response.Data);
                }
                return View(model);
            }
            return View(model);
        }
    }
}
