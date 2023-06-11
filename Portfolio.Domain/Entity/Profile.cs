using Portfolio.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Portfolio.Domain.ViewModels.Profile;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace Portfolio.Domain.Entity
{
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public short Age { get; set; }
        public string PhoneNumber { get; set; }
        public Employment? Employment { get; set; }
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public string? AboutMe { get; set; }
        public string? Experience { get; set; }
        public Image Avatar { get; set; }
        public ICollection<Project> Projects { get; set; }
        public ICollection<SpecialityBox> Specializations { get; set; }
    }

    public static class ProfileExtension
    {
        public static Profile ToModel(this ProfileViewModel viewModel)
        {
            return new Profile()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Age = viewModel.Age,
                PhoneNumber = viewModel.PhoneNumber,
                Employment = viewModel.Employment,
                Experience = viewModel.Experience,
                AboutMe = viewModel.AboutMe,
                Avatar = viewModel.Avatar,
            };
        }

        public static ProfileViewModel ToViewModel(this Profile profile)
        {
            return new ProfileViewModel()
            {
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Age = profile.Age,
                PhoneNumber = profile.PhoneNumber,
                Employment = profile.Employment,
                AboutMe = profile.AboutMe,
                Experience = profile.Experience,
                Avatar = profile.Avatar,
            };
        }

        public static void UpdateProfile(this Profile profile, ProfileViewModel viewModel)
        {
            profile.FirstName = viewModel.FirstName;
            profile.LastName = viewModel.LastName;
            profile.PhoneNumber = viewModel.PhoneNumber;
            profile.AboutMe = viewModel.AboutMe;
            profile.Age = viewModel.Age;
            profile.Employment = viewModel.Employment;
            if (!profile.Avatar.Equals(viewModel.Avatar))
                profile.Avatar = viewModel.Avatar;
        }
    }
}
