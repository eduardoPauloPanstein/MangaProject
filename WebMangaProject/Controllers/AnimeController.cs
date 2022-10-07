﻿using AutoMapper;
using BusinessLogicalLayer.Interfaces.IUserItemService;
using Entities.AnimeS;
using Entities.UserS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi;
using MvcPresentationLayer.Apis.MangaProjectApi.Animes;
using MvcPresentationLayer.Models.AnimeModel;
using MvcPresentationLayer.Utilities;
using Shared.Models.Anime;
using Shared.Responses;

namespace MvcPresentationLayer.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IMangaProjectApiAnimeService _animeApiService;
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiUserService _userApiService;
        private readonly IUserAnimeItemService _userAnimeItem;

        public AnimeController(IMapper mapper, IMangaProjectApiUserService userApiService, IMangaProjectApiAnimeService animeApiService, IUserAnimeItemService userAnimeItem)
        {
            this._animeApiService = animeApiService;
            this._userApiService = userApiService;
            this._mapper = mapper;
            this._userAnimeItem = userAnimeItem;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> AllFavorites()
        {
            DataResponse<AnimeCatalog> responseAnimes = await _animeApiService.GetByFavorites(0, 100);

            if (!responseAnimes.HasSuccess)
            {
                ViewBag.Errors = responseAnimes.Message;
                return View();
            }

            List<AnimeShortViewModel> Animes =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimes.Data);

            return View(Animes);
        }

        [HttpGet]
        public async Task<IActionResult> AnimeOnPage(int id)
        {
            SingleResponse<Anime> responseAnime = await _animeApiService.Get(id, null);
            if (responseAnime.NotFound)
            {
                return NotFound();
            }
            AnimeOnpageViewModel anime = _mapper.Map<AnimeOnpageViewModel>(responseAnime.Item);

            SingleResponse<User> responseUser = new();
            if (User.Identity.IsAuthenticated)
            {
                responseUser = await _userApiService.Get(UserService.GetId(HttpContext), UserService.GetToken(HttpContext));
            }

            UserFavoriteAnimeViewModel userAnimeItem = new();
            bool hasItem = false;

            if (responseUser.HasSuccess && responseUser.Item.AnimeList != null)
            {
                foreach (var item in responseUser.Item.AnimeList)
                {
                    if (item.AnimeId == id)
                    {
                        userAnimeItem = _mapper.Map<UserFavoriteAnimeViewModel>(item);
                        hasItem = true;
                    }
                }
            }

            if (!hasItem)
            {
                userAnimeItem.StartDate = DateTime.Now.Date;
                userAnimeItem.FinishDate = DateTime.Now.Date;
            }

            AnimeItemModalViewModel animeItemModalViewModel = new()
            {
                UserAnimeItem = userAnimeItem,
                Anime = anime
            };
            return View(animeItemModalViewModel);
        }

        #region All
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> All(string by)
        {
            DataResponse<AnimeCatalog> response;

            switch (by)
            {
                case "ByFavorites":
                    response = await _animeApiService.GetByFavorites(0, 99);
                    break;
                case "ByRating":
                    response = await _animeApiService.GetByRating(0, 99);
                    break;
                case "ByUserCount":
                    response = await _animeApiService.GetByUserCount(0, 99);
                    break;
                case "ByPopularity":
                    response = await _animeApiService.GetByPopularity(0, 99);
                    break;
                default:
                    response = new("Whereby??", false, null, null);
                    break;
            }


            if (!response.HasSuccess)
            {
                return BadRequest(response.Message);
            }

            List<AnimeShortViewModel> mangasView =
                _mapper.Map<List<AnimeShortViewModel>>(response.Data);

            return View(mangasView);
        }


        [HttpGet, AllowAnonymous]
        public IActionResult AllByFavorites() => RedirectToAction("All", new { by = "ByFavorites" });
        [HttpGet, AllowAnonymous]
        public IActionResult AllByPopularity() => RedirectToAction("All", new { by = "ByPopularity" });

        [HttpGet, AllowAnonymous]
        public IActionResult AllByRating() => RedirectToAction("All", new { by = "ByRating" });

        [HttpGet, AllowAnonymous]
        public IActionResult AllByUserCount() => RedirectToAction("All", new { by = "ByUserCount" });
        #endregion

        [HttpPost, Authorize]
        public async Task<IActionResult> UserFavorite(AnimeItemModalViewModel fav)
        {
            fav.UserAnimeItem.AnimeId = fav.Anime.Id;
            UserAnimeItem item = this._mapper.Map<UserAnimeItem>(fav.UserAnimeItem);

            item.UserId = UserService.GetId(HttpContext);
            //item.AnimeId = item.Id;
            //item.Id = 0;
            int score = ((int)item.Score);
            Response Response = await _userAnimeItem.Insert(item,score);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("AnimeOnPage", "Anime", new { id = fav.Anime.Id });
        }

        public async Task<IActionResult> Index()
        {
            DataResponse<AnimeCatalog> responseAnimesFavorites = await _animeApiService.GetByFavorites(0, 5);
            DataResponse<AnimeCatalog> responseAnimesByCount = await _animeApiService.GetByUserCount(0, 5);
            DataResponse<AnimeCatalog> responseAnimesByRating = await _animeApiService.GetByRating(0, 5);

            if (!responseAnimesFavorites.HasSuccess || !responseAnimesByCount.HasSuccess || !responseAnimesByRating.HasSuccess)
            {
                return BadRequest(responseAnimesFavorites);
            }

            List<AnimeShortViewModel> animesFavorites =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimesFavorites.Data);

            List<AnimeShortViewModel> animesByCount =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimesByCount.Data);

            List<AnimeShortViewModel> animeesbyrating = _mapper.Map<List<AnimeShortViewModel>>(responseAnimesByRating.Data);

            AnimesForHomeViewModel animesForHomeViewModel = new()
            {
                AnimesFavorites = animesFavorites,
                AnimesByCount = animesByCount,
                AnimesByRating = animeesbyrating
            };

         

            return View(animesForHomeViewModel);
        }
    }
}
