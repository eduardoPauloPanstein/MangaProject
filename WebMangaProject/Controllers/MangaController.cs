using AutoMapper;
using BusinessLogicalLayer.Interfaces.IMangaInterfaces;
using Entities.MangaS;
using Entities.UserS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi;
using MvcPresentationLayer.Apis.MangaProjectApi.Mangas;
using MvcPresentationLayer.Models.MangaModels;
using MvcPresentationLayer.Utilities;
using Shared.Responses;


namespace MvcPresentationLayer.Controllers
{
    public class MangaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiMangaService _mangaApiService;
        private readonly IMangaProjectApiUserService _userApiService;
        private readonly IMangaService _mangaService;

        public MangaController(IMangaService svc, IMapper mapper, IMangaProjectApiMangaService mangaApiService, IMangaProjectApiUserService userService, IMangaService mangaService)
        {
            this._userApiService = userService;
            this._mapper = mapper;
            this._mangaApiService = mangaApiService;
            this._mangaService = mangaService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            DataResponse<Manga> responseFavorites = await _mangaApiService.GetByFavorites(0, 5);
            DataResponse<Manga> responseCount = await _mangaApiService.GetByUserCount(0, 5);
            DataResponse<Manga> responserating = await _mangaApiService.GetByRating(0, 5);

            if (!responseFavorites.HasSuccess || !responseCount.HasSuccess || !responserating.HasSuccess)
            {
                return BadRequest(responseFavorites);
            }

            List<MangaShortViewModel> favo =
                _mapper.Map<List<MangaShortViewModel>>(responseFavorites.Data);

            List<MangaShortViewModel> Count =
                _mapper.Map<List<MangaShortViewModel>>(responseCount.Data);

            List<MangaShortViewModel> rating = _mapper.Map<List<MangaShortViewModel>>(responserating.Data);

            MangasForHomeViewModel MangasForHomeViewModel = new()
            {
                MangasFavorites = favo,
                MangasByCount = Count,
                MangasByRating = rating
            };
            return View(MangasForHomeViewModel);
        }

        #region All
        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> All(string by)
        {
            DataResponse<Manga> response;

            switch (by)
            {
                case "ByFavorites":
                    response = await _mangaApiService.GetByFavorites(0, 99);
                    break;
                case "ByRating":
                    response = await _mangaApiService.GetByRating(0, 99);
                    break;
                case "ByUserCount":
                    response = await _mangaApiService.GetByUserCount(0, 99);
                    break;
                case "ByPopularity":
                    response = await _mangaApiService.GetByFavorites(0, 99);
                    break;
                default:
                    response = new("Whereby??", false, null, null);
                    break;
            }


            if (!response.HasSuccess)
            {
                return BadRequest(response.Message);
            }

            List<MangaShortViewModel> mangasView =
                _mapper.Map<List<MangaShortViewModel>>(response.Data);

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

        [HttpGet]
        public async Task<IActionResult> MangaOnPage(int id)
        {
            var responseUser = await _userApiService.Get(UserService.GetId(HttpContext), UserService.GetToken(HttpContext));
            SingleResponse<Manga> responseManga = await _mangaApiService.Get(id,null);

            if (!responseManga.HasSuccess)
            {
                return NotFound();
            }

            var manga = _mapper.Map<MangaOnPageViewModel>(responseManga.Data);

            var user = _mapper.Map<UserFavoriteMangaViewModel>(responseUser.Data);
            if (user != null)
            {
                if(user.StartDate != null)
                {
                    user.StartDate = DateTime.Now.Date;
                }
                if(user.FinishDate != null)
                {
                    user.FinishDate = DateTime.Now.Date;

                }
            }

            MangaItemModalViewModel mangaItemModalViewModel = new()
            {
                User = user,
                Manga = manga
            };

            return View(mangaItemModalViewModel);
        }


        public async Task<IActionResult> GetSuggestionList(string title)
        {
            DataResponse<Manga> response = await _mangaApiService.Get(title);
            return Json(new { resultado = response.Data });
        }

        [HttpGet, Authorize]
        public async Task<ActionResult> UserFavorite()
        {
            return View();
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> UserFavorite(UserFavoriteMangaViewModel fav)
        {
           
            UserMangaItem item = this._mapper.Map<UserMangaItem>(fav);

            item.UserId = UserService.GetId(HttpContext);
            item.MangaId = item.Id;
            item.Id = 0;

            Response Response = await _userApiService.AddUserMangaItem(item, UserService.GetToken(HttpContext));
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("MangaOnPage", "Manga", new {id = fav.Id});
        }
    }

}
