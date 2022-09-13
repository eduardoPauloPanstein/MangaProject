using AutoMapper;
using BusinessLogicalLayer.Interfaces.IMangaInterfaces;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using Entities.MangaS;
using Entities.UserS;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi.Mangas;
using MvcPresentationLayer.Models.MangaModels;
using Shared.Responses;

namespace MvcPresentationLayer.Controllers
{
    public class MangaController : Controller
    {
        private readonly IMangaService _mangaService;
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiMangaService _mangaApiService;
        private readonly IUserService _userService;
        public MangaController(IMangaService svc, IMapper mapper, IMangaProjectApiMangaService mangaApiService, IUserService userService)
        {
            this._userService = userService;
            this._mapper = mapper;
            this._mangaService = svc;
            this._mangaApiService = mangaApiService;
        }
        //MangaController/AllFavorites
        public async Task<IActionResult> AllFavorites()
        {
            DataResponse<Manga> responseMangas = await _mangaService.GetAllByFavorites();

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
            SingleResponse<Manga> response = await _mangaService.Select(id);
            if (!response.HasSuccess)
            {
                return NotFound();
            }

            var manga = _mapper.Map<MangaOnPageViewModel>(response.Data);

            return View(manga);
        }

        public class Rootobject
        {
            public Datum[] data { get; set; }
            public string message { get; set; }
            public bool hasSuccess { get; set; }
            public object exception { get; set; }
        }

        //TESTE

        public async Task<IActionResult> GetSuggestionListTeste(string title)
        {
            DataResponse<Manga> response = await _mangaApiService.Select(title);
            return Json(new { resultado = response.Data });
        }
        public async Task<ActionResult> UserFavorite()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserFavorite(UserFavoriteMangaViewModel Fav, int id)
        {
            UserMangaItem item = this._mapper.Map<UserMangaItem>(Fav);

            item.User = 1;
            item.Manga = id;
            item.Id = 0;
               
            
            Response Response = await _userService.FavoriteManga(item);
            return RedirectToAction("Index","Home");
        }
    }

}
