using MvcPresentationLayer.Models.MangaModels;

namespace MvcPresentationLayer.Models.AnimeModel
{
    public class AnimeItemModalViewModel
    {
        public UserFavoriteAnimeViewModel UserAnimeItem { get; set; }
        public AnimeOnpageViewModel Anime { get; set; }
    }
}
