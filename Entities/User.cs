﻿using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public bool EmailConfirmed { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastLogin { get; set; }
        public UserRoles Role { get; set; } = UserRoles.User;
        public string? About { get; set; }
        //public CivicAddress Address { get; set; }
        public int FavoritesCount { get; set; }
        public int ReviewsCount { get; set; }
        public string? AvatarImage { get; set; }
        public string? CoverImage { get; set; }
        public bool KeepLogged { get; set; }
    }
    //Se não confirmar email não acessa, e fica registrado na DB?
}