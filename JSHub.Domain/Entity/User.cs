﻿using System.ComponentModel.DataAnnotations;

namespace JSHub.Domain.Entity
{
    public class User
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public Profile Profile { get; set; }
    }
}
