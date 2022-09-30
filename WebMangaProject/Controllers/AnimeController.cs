using AutoMapper;
using BusinessLogicalLayer.Interfaces.IAnimeInterfaces;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using Entities.AnimeS;
using Entities.UserS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi;
using MvcPresentationLayer.Apis.MangaProjectApi.Animes;
using MvcPresentationLayer.Models.AnimeModel;
using MvcPresentationLayer.Utilities;
using Shared.Responses;

namespace MvcPresentationLayer.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IMangaProjectApiAnimeService _animeApiService;
        private readonly IAnimeService _AnimeService;
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiUserService _userApiService;
        private readonly IUserService _userService;

        public AnimeController(IAnimeService AnimeService, IMapper mapper,IMangaProjectApiUserService userApiService,IUserService userService, IMangaProjectApiAnimeService animeApiService)
        {
            this._animeApiService = animeApiService;
            this._userService = userService;
            this._userApiService = userApiService;
            this._AnimeService = AnimeService;
            this._mapper = mapper;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> AllFavorites()
        {
            DataResponse<Anime> responseAnimes = await _animeApiService.GetByFavorites(0, 100);

            if (!responseAnimes.HasSuccess)
            {
                ViewBag.Errors = responseAnimes.Message;
                return View();
            }

            List<AnimeShortViewModel> Animes =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimes.Data);

            return View(Animes);
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> AnimeOnPage(int id)
        {
            var responseUser = await _userApiService.Get(UserService.GetId(HttpContext), UserService.GetToken(HttpContext));
            SingleResponse<Anime> responseAnime = await _animeApiService.Get(id,null);

            if (!responseAnime.HasSuccess || !responseUser.HasSuccess)
            {
                return NotFound();
            }

            var anime = _mapper.Map<AnimeOnpageViewModel>(responseAnime.Item);

            var user = _mapper.Map<UserFavoriteAnimeViewModel>(responseUser.Item);

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
