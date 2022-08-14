using Entities.Enums;
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
        public DateOnly CreatedAt
        {
            get
            {
                return DateOnly.FromDateTime(DateTime.Now);
            }
        }
        public DateOnly LastLogin { get; set; }
        public UserRoles Role { get; set; } = UserRoles.User;
        public string? About { get; set; }
        //public CivicAddress Address { get; set; }
        public int FavoritesCount { get; set; }
        public int ReviewsCount { get; set; }
        public string? CoverImageLink { get; set; }
        public string? AvatarImageLink { get; set; }
        public bool KeepLogged { get; set; }
    }
    //Se não confirmar email não acessa, e fica registrado na DB?
}
