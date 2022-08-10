using System.ComponentModel.DataAnnotations;

namespace MvcPresentationLayer.Models.Manga
{
    public class MangaShortDbViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        public string CanonicalTitle { get; set; }
        public int? FavoritesCount { get; set; }

    }
}
