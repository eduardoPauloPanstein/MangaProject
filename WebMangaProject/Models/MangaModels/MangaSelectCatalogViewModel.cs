using Entities.MangaS;
using System.ComponentModel.DataAnnotations;

namespace MvcPresentationLayer.Models.MangaModels
{
    public class MangaSelectCatalogViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MangaTitles? Titles { get; set; }

        [Display(Name = "Title")]
        public string CanonicalTitle { get; set; }
        [Display(Name = "Favorites Count")]
        public int? FavoritesCount { get; set; }
        public string PosterImageLink { get; set; }
    }
}
