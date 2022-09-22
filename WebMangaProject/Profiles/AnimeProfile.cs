using AutoMapper;
using Entities.AnimeS;
using MvcPresentationLayer.Models.AnimeModel;

namespace MvcPresentationLayer.Profiles
{
    public class AnimeProfile : Profile
    {
        public AnimeProfile()
        {
            CreateMap<AnimeSelectViewModel, Anime>();
            CreateMap<Anime, AnimeSelectViewModel>();

            //CreateMap<MangaShortDbViewModel, Anime>();
            //CreateMap<Manga, MangaShortDbViewModel>();

            CreateMap<AnimeOnpageViewModel, Anime>();
            CreateMap<Anime, AnimeOnpageViewModel>();
        }
    }
}
