﻿using AutoMapper;
using BusinessLogicalLayer.Interfaces.IAnimeInterfaces;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using Entities.AnimeS;
using Entities.MangaS;
using Entities.UserS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi;
using MvcPresentationLayer.Models.AnimeModel;
using MvcPresentationLayer.Models.MangaModels;
using MvcPresentationLayer.Utilities;
using Shared.Responses;

namespace MvcPresentationLayer.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IAnimeService _AnimeService;
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiUserService _userApiService;
        private readonly IUserService _userService;

        public AnimeController(IAnimeService AnimeService, IMapper mapper,IMangaProjectApiUserService userApiService,IUserService userService)
        {
            this._userService = userService;
            this._userApiService = userApiService;
            this._AnimeService = AnimeService;
            this._mapper = mapper;
        }
        public async Task<IActionResult> AllFavorites()
        {
            DataResponse<Anime> responseAnimes = await _AnimeService.GetByFavorites(0, 100);

            if (!responseAnimes.HasSuccess)
            {
                ViewBag.Errors = responseAnimes.Message;
                return View();
            }

            List<AnimeShortViewModel> Animes =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimes.Data);

            return View(Animes);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> AnimeOnPage(int id)
        {
            var responseUser = await _userApiService.Get(UserService.GetId(HttpContext), UserService.GetToken(HttpContext));
            SingleResponse<Anime> responseAnime = await _AnimeService.Get(id);

            if (!responseAnime.HasSuccess || !responseUser.HasSuccess)
            {
                return NotFound();
            }

            var anime = _mapper.Map<AnimeOnpageViewModel>(responseAnime.Data);

            var user = _mapper.Map<UserFavoriteAnimeViewModel>(responseUser.Data);

            AnimeItemModalViewModel animeItemModalViewModel = new()
            {
                User = user,
                Anime = anime
            };
            return View(animeItemModalViewModel);
        }
        [HttpGet, Authorize]
        public async Task<ActionResult> UserFavorite()
        {
            return View();
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> UserFavorite(UserFavoriteAnimeViewModel fav,int id)
        {

            UserAnimeItem item = this._mapper.Map<UserAnimeItem>(fav);

            item.UserId = UserService.GetId(HttpContext);
            item.AnimeId = item.Id;
            item.Id = 0;

            Response Response = await _userService.AddUserAnimeItem(item);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("AnimeOnPage", "Anime", new { id = fav.Id });
        }
        public async Task<IActionResult> Index()
        {
            DataResponse<Anime> responseAnimesFavorites = await _AnimeService.GetByFavorites(0, 6);
            DataResponse<Anime> responseAnimesByCount = await _AnimeService.GetByUserCount(0, 6);
            DataResponse<Anime> responseAnimesByRating = await _AnimeService.GetByRating(0, 6);

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
