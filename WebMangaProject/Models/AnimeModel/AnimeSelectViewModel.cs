using Entities.AnimeS;
using System.ComponentModel.DataAnnotations;

namespace MvcPresentationLayer.Models.AnimeModel
{
    public class AnimeSelectViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public AnimeSTitles? AnimeTitles { get; set; }

        [Display(Name = "Title")]
        public string canonicalTitle { get; set; }
        [Display(Name = "Favorites Count")]
        public int? favoritesCount { get; set; }
        public string? AnimePosterImage { get; set; }
        public string? AnimeCoverImage { get; set; }
    }
}
