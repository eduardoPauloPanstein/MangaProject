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

            List<AnimeSelectViewModel> Animes =
                _mapper.Map<List<AnimeSelectViewModel>>(responseAnimes.Data);

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
            DataResponse<Anime> responseAnime = await _AnimeService.GetByFavorites(0, 100);
            if (!responseAnime.HasSuccess)
            {
                ViewBag.Errors = responseAnime.Message;
                return View();
            }

            List<AnimeSelectViewModel> animes =
                _mapper.Map<List<AnimeSelectViewModel>>(responseAnime.Data);

            return View(animes);
        }


    }
}
