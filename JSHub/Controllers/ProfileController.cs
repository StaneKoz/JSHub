﻿
using Azure;
using JSHub.Domain.ViewModels.Profile;
using JSHub.Service.Implementations;
using JSHub.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JSHub.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet]
        public IActionResult Create()
        {
/*            if (_profileService.GetProfile(long.Parse(User.Identity.Name)) != null) 
                return RedirectToAction("BadRequest", "Home");*/
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
            if (response.StatusCode == JSHub.Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            else if (response.StatusCode == JSHub.Domain.Enum.StatusCode.ProfileNotFound)
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
        public IActionResult Update(ProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _profileService.UpdateProfile(model, long.Parse(User.Identity.Name));
                if (response.StatusCode == JSHub.Domain.Enum.StatusCode.OK)
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
