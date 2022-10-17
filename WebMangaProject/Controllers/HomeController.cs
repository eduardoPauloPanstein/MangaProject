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
using Shared.Models.Anime;
using Shared.Models.Manga;
using System.Security.Claims;

namespace MvcPresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiAnimeService _animeApiService;
        private readonly IMangaProjectApiMangaService _mangaApiService;

        public HomeController(IMapper mapper, IMangaProjectApiAnimeService animeApiService, IMangaProjectApiMangaService mangaApiService)
        {
            this._animeApiService = animeApiService;
            this._mapper = mapper;
            this._mangaApiService = mangaApiService;
        }
        public async Task<IActionResult> Index()
        {
            //Código que o celo fez
            //List<Claim> claims = this.User.Claims.ToList();
            //int idCliente = int.Parse(claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.PrimarySid).Value);
            //string role = claims.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Role).Value;


            DataResponse<AnimeCatalog> responseAnimesFavorites = await _animeApiService.GetByFavorites(0, 7);
            DataResponse<AnimeCatalog> responseAnimesByCount = await _animeApiService.GetByUserCount(0, 7);
            DataResponse<AnimeCatalog> responseAnimesByRating = await _animeApiService.GetByRating(0, 7);

            if (!responseAnimesFavorites.HasSuccess || !responseAnimesByCount.HasSuccess || !responseAnimesByRating.HasSuccess)
            {
                return BadRequest(responseAnimesFavorites);
            }

            List<AnimeShortViewModel> animesFavorites =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimesFavorites.Data);

            List<AnimeShortViewModel> animesByCount =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimesByCount.Data);

            List<AnimeShortViewModel> animesByRating = _mapper.Map<List<AnimeShortViewModel>>(responseAnimesByRating.Data);


            DataResponse<MangaCatalog> responseMangaFavorites = await _mangaApiService.GetByFavorites(0, 7);
            DataResponse<MangaCatalog> responseMangaCount = await _mangaApiService.GetByUserCount(0, 7);
            DataResponse<MangaCatalog> responseMangaRating = await _mangaApiService.GetByRating(0, 7);

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