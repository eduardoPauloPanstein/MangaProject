using Entities.Manga;
using System.ComponentModel.DataAnnotations;

namespace MvcPresentationLayer.Models.Manga
{
    public class MangaSelectCatalogViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MangaTitles? Titles { get; set; }

        [Display(Name = "Título")]
        public string CanonicalTitle { get; set; }
        public int? FavoritesCount { get; set; }
        public string PosterImageLink { get; set; }
    }
}
