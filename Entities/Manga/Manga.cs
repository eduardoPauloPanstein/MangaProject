using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Manga
{
    public class Manga
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public MangaTitles? Titles { get; set; }
        public string? CanonicalTitle { get; set; }
        public string? AverageRating { get; set; }
        public RatingFrequencies? RatingFrequencies { get; set; }
        public int? RatingRank { get; set; }
        public int? PopularityRank { get; set; }
        public int? UserCount { get; set; }
        public int? FavoritesCount { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? AgeRating { get; set; }
        public string? AgeRatingGuide { get; set; } //Enum -> exemplo: R18 Explicit
        public MangaStatus? Status { get; set; } 
        public int? VolumeCount { get; set; }
        public string? Serialization { get; set; } //Ver generos
        public string PosterImageLink { get; set; }
        public string? CoverImageLink { get; set; }
        public ICollection<User> UserID { get; set; }

    }
}
