using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UserS
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
        public string? AvatarImageFileLocation { get; set; }
        public string? CoverImageFileLocation { get; set; }
        public bool KeepLogged { get; set; }
        public ICollection<UserMangaItem> MangaList { get; set; }
    }
}
