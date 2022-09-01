﻿using Entities.Enums;
using Entities.Manga;
using System.ComponentModel.DataAnnotations;

namespace MvcPresentationLayer.Models.Manga
{
    public class MangaOnPageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Synopsis { get; set; }
        public MangaTitles? Titles { get; set; }
        public string? CanonicalTitle { get; set; }
        public string? AverageRating { get; set; }
        public int? RatingRank { get; set; }
        public int? PopularityRank { get; set; }
        public int? UserCount { get; set; }
        public int? FavoritesCount { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? AgeRating { get; set; }
        public string? AgeRatingGuide { get; set; } 
        public MangaStatus? Status { get; set; }
        public int? VolumeCount { get; set; }
        public string? Serialization { get; set; } 
        public string? CoverImageLink { get; set; }
    }
}