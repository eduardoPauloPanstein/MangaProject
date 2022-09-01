using AutoMapper;
using Entities.Manga;
using MvcPresentationLayer.Models.Manga;

namespace MvcPresentationLayer.Profiles
{
    public class MangaProfile : Profile
    {
        public MangaProfile()
        {
            CreateMap<MangaSelectCatalogViewModel, Manga>();
            CreateMap<Manga, MangaSelectCatalogViewModel>();

            CreateMap<MangaShortDbViewModel, Manga>();
            CreateMap<Manga, MangaShortDbViewModel>();

            CreateMap<MangaOnPageViewModel, Manga>();
            CreateMap<Manga, MangaOnPageViewModel>();
        }
    }
}
