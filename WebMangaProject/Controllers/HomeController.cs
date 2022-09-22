using AutoMapper;
using BusinessLogicalLayer.Interfaces.IMangaInterfaces;
using Entities.MangaS;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi.Mangas;
using MvcPresentationLayer.Models.MangaModels;
using Shared.Responses;
using System.Diagnostics;
using WebMangaProject.Models;

namespace WebMangaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMangaProjectApiMangaService _mangaApiService;
        private readonly IMapper _mapper;


        public HomeController(ILogger<HomeController> logger, IMapper mapper, IMangaProjectApiMangaService mangaApi)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mangaApiService = mangaApi;
        }

        public async Task<IActionResult> Index()
        {
            DataResponse<Manga> responseMangas = await _mangaApiService.GetByFavorites(0,1);
            if (!responseMangas.HasSuccess)
            {
                ViewBag.Errors = responseMangas.Message;
                return View();
            }

            List<MangaSelectCatalogViewModel> mangas =
                _mapper.Map<List<MangaSelectCatalogViewModel>>(responseMangas.Data);

            return View(mangas);
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
    }
}