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
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Shared;

namespace MvcPresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiAnimeService _animeApiService;
        private readonly IMangaProjectApiMangaService _mangaApiService;
        private readonly IDistributedCache _distributedCache;

        public HomeController(IMapper mapper, IMangaProjectApiAnimeService animeApiService, IMangaProjectApiMangaService mangaApiService, IDistributedCache distributedCache)
        {
            this._animeApiService = animeApiService;
            this._mapper = mapper;
            this._mangaApiService = mangaApiService;
            this._distributedCache = distributedCache;
        }

        public async Task<IActionResult> Index()
        {


            //DataResponse<AnimeCatalog> responseAnimesFavorites = await _animeApiService.GetByFavorites(0, 7);
            var responseAnimesFavorites = await GetTop7AnimesCatalogByFavorites();
            var responseAnimesByCount = await GetTop7AnimesCatalogByUserCount();
            var responseAnimesByRating = await GetTop7AnimesCatalogByRating();

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
        #region Utilites
        private async Task<DataResponse<AnimeCatalog>> GetTop7AnimesCatalogByFavorites()
        {
            var json = await _distributedCache.GetStringAsync(LocationConstants.CacheKey.Anime.GetTop7AnimesCatalogByFavorites);
            if (json != null)
            {
                var animeCatalog = JsonConvert.DeserializeObject<List<AnimeCatalog>>(json);
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(animeCatalog);
            }
            else
            {
                DataResponse<AnimeCatalog> response = await _animeApiService.GetByFavorites(0, 7);
                if (response.HasSuccess)
                {
                    json = JsonConvert.SerializeObject(response.Data);
                    await _distributedCache.SetStringAsync(LocationConstants.CacheKey.Manga.GetByFavorites, json);
                }
                return response;
            }
        }
        private async Task<DataResponse<AnimeCatalog>> GetTop7AnimesCatalogByUserCount()
        {
            var json = await _distributedCache.GetStringAsync(LocationConstants.CacheKey.Anime.GetTop7AnimesCatalogByUserCount);
            if (json != null)
            {
                var animeCatalog = JsonConvert.DeserializeObject<List<AnimeCatalog>>(json);
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(animeCatalog);
            }
            else
            {
                DataResponse<AnimeCatalog> response = await _animeApiService.GetByUserCount(0, 7);
                if (response.HasSuccess)
                {
                    json = JsonConvert.SerializeObject(response.Data);
                    await _distributedCache.SetStringAsync(LocationConstants.CacheKey.Manga.GetByFavorites, json);
                }
                return response;
            }
        }
        private async Task<DataResponse<AnimeCatalog>> GetTop7AnimesCatalogByRating()
        {
            var json = await _distributedCache.GetStringAsync(LocationConstants.CacheKey.Anime.GetTop7AnimesCatalogByRating);
            if (json != null)
            {
                var animeCatalog = JsonConvert.DeserializeObject<List<AnimeCatalog>>(json);
                return ResponseFactory.CreateInstance().CreateResponseBasedOnCollectionData(animeCatalog);
            }
            else
            {
                DataResponse<AnimeCatalog> response = await _animeApiService.GetByRating(0, 7);
                if (response.HasSuccess)
                {
                    json = JsonConvert.SerializeObject(response.Data);
                    await _distributedCache.SetStringAsync(LocationConstants.CacheKey.Manga.GetByFavorites, json);
                }
                return response;
            }
        }
        #endregion
    }
}