using MvcPresentationLayer.Models.MangaModels;

namespace MvcPresentationLayer.Models.AnimeModel
{
    public class AnimeItemModalViewModel
    {
        public UserFavoriteAnimeViewModel User { get; set; }
        public AnimeOnpageViewModel Anime { get; set; }
    }
}
