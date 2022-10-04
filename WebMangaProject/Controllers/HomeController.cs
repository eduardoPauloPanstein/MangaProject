using AutoMapper;
using BusinessLogicalLayer.Interfaces.IAnimeInterfaces;
using Entities.AnimeS;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi.Animes;
using MvcPresentationLayer.Apis.MangaProjectApi;
using Shared.Responses;
using System.Diagnostics;
using WebMangaProject.Models;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using MvcPresentationLayer.Models.AnimeModel;
using MvcPresentationLayer.Apis.MangaProjectApi.Mangas;
using BusinessLogicalLayer.Interfaces.IMangaInterfaces;
using Entities.MangaS;
using MvcPresentationLayer.Models.MangaModels;
using MvcPresentationLayer.Models.HomePage;

namespace MvcPresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiAnimeService _animeApiService;
        private readonly IAnimeService _AnimeService;
        private readonly IMangaProjectApiMangaService _mangaApiService;
        private readonly IMangaService _mangaService;

        public HomeController(IAnimeService AnimeService, IMapper mapper, IMangaProjectApiAnimeService animeApiService, IMangaProjectApiMangaService mangaApiService, IMangaService mangaService)
        {
            this._animeApiService = animeApiService;
            this._AnimeService = AnimeService;
            this._mapper = mapper;
            this._mangaApiService = mangaApiService;
            this._mangaService = mangaService;
        }
        public async Task<IActionResult> Index()
        {
            DataResponse<Anime> responseAnimesFavorites = await _animeApiService.GetByFavorites(0, 5);
            DataResponse<Anime> responseAnimesByCount = await _animeApiService.GetByUserCount(0, 5);
            DataResponse<Anime> responseAnimesByRating = await _animeApiService.GetByRating(0, 5);

            if (!responseAnimesFavorites.HasSuccess || !responseAnimesByCount.HasSuccess || !responseAnimesByRating.HasSuccess)
            {
                return BadRequest(responseAnimesFavorites);
            }

            List<AnimeShortViewModel> animesFavorites =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimesFavorites.Data);

            List<AnimeShortViewModel> animesByCount =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimesByCount.Data);

            List<AnimeShortViewModel> animesByRating = _mapper.Map<List<AnimeShortViewModel>>(responseAnimesByRating.Data);


            DataResponse<Manga> responseMangaFavorites = await _mangaApiService.GetByFavorites(0, 5);
            DataResponse<Manga> responseMangaCount = await _mangaApiService.GetByUserCount(0, 5);
            DataResponse<Manga> responseMangaRating = await _mangaApiService.GetByRating(0, 5);

            if (!responseMangaFavorites.HasSuccess || !responseMangaCount.HasSuccess || !responseMangaRating.HasSuccess)
            {
                return BadRequest(responseMangaFavorites);
            }

            List<MangaShortViewModel> MangaFavorite =
                _mapper.Map<List<MangaShortViewModel>>(responseMangaFavorites.Data);

            List<MangaShortViewModel> MangaCount =
                _mapper.Map<List<MangaShortViewModel>>(responseMangaCount.Data);

            List<MangaShortViewModel> MangaRating = _mapper.Map<List<MangaShortViewModel>>(responseMangaRating.Data);

            HomePageViewModel homePageViewModel = new()
            {
                MangasFavorites = MangaFavorite,
                MangasByCount = MangaCount,
                MangasByRating = MangaRating,
                AnimesFavorites = animesFavorites,
                AnimesByCount = animesByCount,
                AnimesByRating = animesByRating,
            };
            return View(homePageViewModel);
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}