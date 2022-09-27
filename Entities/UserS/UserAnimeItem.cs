﻿using Entities.AnimeS;
using Entities.Enums;

namespace Entities.UserS
{
    public class UserAnimeItem : Entity
    {
        public UserAnimeItem(Anime anime, User user)
        {
            this.Anime = anime;
            this.User = user;
        }
        public UserAnimeItem()
        {

        }

        public Anime Anime { get; set; }
        public int AnimeId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public UserMangaStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public MangaScore? Score { get; set; }
        public int? TotalRereads { get; set; }
        public int? Chapter { get; set; }
        public int? Volume { get; set; }
        public string? PrivateNotes { get; set; }
        public string? PublicNotes { get; set; }
        public bool Private { get; set; }
        public bool Favorite { get; set; }
    }
}
