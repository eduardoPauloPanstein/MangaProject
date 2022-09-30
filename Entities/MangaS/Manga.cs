using Entities.Enums;

namespace Entities.MangaS
{
    public class Manga : Entity
    {
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
        public MangaStatus? Status { get; set; } 
        public int? VolumeCount { get; set; }
        public string? Serialization { get; set; } 
        public string PosterImageLink { get; set; }
        public string? CoverImageLink { get; set; }
        public ICollection<Category> Categoria { get; set; }
    }
}
