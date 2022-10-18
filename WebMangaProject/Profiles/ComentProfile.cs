using AutoMapper;
using Entities.MangaS;
using MvcPresentationLayer.Models.AnimeModel;
using MvcPresentationLayer.Models.MangaModels;
using Shared.Models.Anime;

namespace MvcPresentationLayer.Profiles
{
    public class ComentProfile:Profile
    {
        public ComentProfile()
        {
            CreateMap<MangaComentaryViewModel, MangaComentary>();
            CreateMap<AnimeComentaryViewModel, MangaComentary>();

        }
    }
}
