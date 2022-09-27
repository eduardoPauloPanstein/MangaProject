﻿using Entities;
using Entities.AnimeS;
using Entities.Enums;

namespace MvcPresentationLayer.Models.AnimeModel
{
    public class AnimeOnpageViewModel
    {
        public int Id { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public string? name { get; set; }
        public string? synopsis { get; set; }
        public string? description { get; set; }
        public AnimeSTitles? AnimeTitles { get; set; }
        public string? canonicalTitle { get; set; }
        public string? averageRating { get; set; }
        public AnimeRatingFrequencies? AnimeRatingFrequencies { get; set; }
        public int? userCount { get; set; }
        public int? favoritesCount { get; set; }
        public string? startDate { get; set; }
        public string? endDate { get; set; }
        public int? popularityRank { get; set; }
        public int? ratingRank { get; set; }
        public string? ageRating { get; set; }
        public string? ageRatingGuide { get; set; }
        public string? subtype { get; set; }
        public MangaStatus? status { get; set; }
        public string? AnimePosterImage { get; set; }
        public string? AnimeCoverImage { get; set; }
        public int? episodeCount { get; set; }
        public int? episodeLength { get; set; }
        public int? totalLength { get; set; }
        public string? youtubeVideoId { get; set; }
        public string? showType { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
