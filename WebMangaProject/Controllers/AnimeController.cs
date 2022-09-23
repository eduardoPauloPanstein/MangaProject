using AutoMapper;
using BusinessLogicalLayer.Interfaces.IAnimeInterfaces;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using Entities.AnimeS;
using Entities.UserS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi;
using MvcPresentationLayer.Models.AnimeModel;
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

        public async Task<IActionResult> AnimeOnPage(int id)
        {
            SingleResponse<Anime> response = await _AnimeService.Get(id);
            if (!response.HasSuccess)
            {
                return NotFound();
            }

            var manga = _mapper.Map<AnimeOnpageViewModel>(response.Data);

            return View(manga);
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
            DataResponse<Anime> responseAnimesFavorites = await _AnimeService.GetByFavorites(0, 100);
            DataResponse<Anime> responseAnimesByCount = await _AnimeService.GetByUserCount(0, 100);


            if (!responseAnimesFavorites.HasSuccess || !responseAnimesByCount.HasSuccess)
            {
                return BadRequest(responseAnimesFavorites);
            }

            List<AnimeShortViewModel> animesFavorites =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimesFavorites.Data);

            List<AnimeShortViewModel> animesByCount =
                _mapper.Map<List<AnimeShortViewModel>>(responseAnimesByCount.Data);

            AnimesForHomeViewModel animesForHomeViewModel = new()
            {
                AnimesFavorites = animesFavorites,
                AnimesByCount = animesByCount

            };


            return View(animesForHomeViewModel);
        }


    }
}
