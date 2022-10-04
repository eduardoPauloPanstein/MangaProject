using AutoMapper;
using BusinessLogicalLayer.Interfaces.IUserItemService;
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
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiUserService _userApiService;
        private readonly IUserAnimeItemService _userAnimeItem;

        public AnimeController(IMapper mapper,IMangaProjectApiUserService userApiService, IMangaProjectApiAnimeService animeApiService, IUserAnimeItemService userAnimeItem)
        {
            this._animeApiService = animeApiService;
            this._userApiService = userApiService;
            this._mapper = mapper;
            this._userAnimeItem = userAnimeItem;
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

        [HttpGet]
        public async Task<IActionResult> AnimeOnPage(int id)
        {
            var responseUser = await _userApiService.Get(UserService.GetId(HttpContext), UserService.GetToken(HttpContext));
            SingleResponse<Anime> responseAnime = await _animeApiService.Get(id,null);

            if (!responseAnime.HasSuccess)
            {
                return NotFound();
            }

            var anime = _mapper.Map<AnimeOnpageViewModel>(responseAnime.Item);

            var user = _mapper.Map<UserFavoriteAnimeViewModel>(responseUser.Item);
            if (user != null)
            {
                if (user.StartDate != null)
                {
                    user.StartDate = DateTime.Now.Date;
                }
                if (user.FinishDate != null)
                {
                    user.FinishDate = DateTime.Now.Date;
                }
            }

            AnimeItemModalViewModel animeItemModalViewModel = new()
            {
                User = user,
                Anime = anime
            };
            return View(animeItemModalViewModel);
        }

        #region All
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> All(string by)
        {
            DataResponse<Anime> response;

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
                    response = await _animeApiService.GetByFavorites(0, 99);
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
        public async Task<IActionResult> UserFavorite(UserFavoriteAnimeViewModel fav)
        {

            UserAnimeItem item = this._mapper.Map<UserAnimeItem>(fav);

            item.UserId = UserService.GetId(HttpContext);
            item.AnimeId = item.Id;
            item.Id = 0;

            Response Response = await _userAnimeItem.Insert(item);
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
