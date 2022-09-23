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

        public MangaController(IMangaService svc, IMapper mapper, IMangaProjectApiMangaService mangaApiService, IMangaProjectApiUserService userService)
        {
            this._userApiService = userService;
            this._mapper = mapper;
            this._mangaApiService = mangaApiService;
        }
        public async Task<IActionResult> Index()
        {
            DataResponse<Manga> responseMangas = await _mangaApiService.GetByFavorites(0, 1);
            if (!responseMangas.HasSuccess)
            {
                ViewBag.Errors = responseMangas.Message;
                return View();
            }

            List<MangaSelectCatalogViewModel> mangas =
                _mapper.Map<List<MangaSelectCatalogViewModel>>(responseMangas.Data);

            return View(mangas);
        }
        public async Task<IActionResult> AllFavorites()
        {
            DataResponse<Manga> responseMangas = await _mangaApiService.GetByFavorites(0, 100);

            if (!responseMangas.HasSuccess)
            {
                ViewBag.Errors = responseMangas.Message;
                return View();
            }

            List<MangaSelectCatalogViewModel> mangas =
                _mapper.Map<List<MangaSelectCatalogViewModel>>(responseMangas.Data);

            return View(mangas);
        }

        public async Task<IActionResult> MangaOnPage(int id)
        {
            var responseUser = await _userApiService.Get(UserService.GetId(HttpContext), UserService.GetToken(HttpContext));
            SingleResponse<Manga> responseManga = await _mangaApiService.Get(id, null);

            if (!responseManga.HasSuccess || !responseUser.HasSuccess)
            {
                return NotFound();
            }

            var manga = _mapper.Map<MangaOnPageViewModel>(responseManga.Data);
            var user = _mapper.Map<UserFavoriteMangaViewModel>(responseUser.Data);

            MangaItemModalViewModel mangaItemModalViewModel = new()
            {
                User = user,
                Manga = manga
            };

            return View(mangaItemModalViewModel);
        }

        //public class Rootobject
        //{
        //    public Datum[] data { get; set; }
        //    public string message { get; set; }
        //    public bool hasSuccess { get; set; }
        //    public object exception { get; set; }
        //}


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
