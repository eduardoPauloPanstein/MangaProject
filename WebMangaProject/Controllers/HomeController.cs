using ApiConsumer;
using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities.Manga;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Models.Manga;
using Shared;
using System.Diagnostics;
using WebMangaProject.Models;

namespace WebMangaProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMangaService _mangaService;
        private readonly IMapper _mapper;
        private readonly IApiConnect _apiService;


        public HomeController(ILogger<HomeController> logger, IMangaService svc, IMapper mapper, IApiConnect apiConnect)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._mangaService = svc;
            this._apiService = apiConnect;
        }

        public async Task<IActionResult> Index()
        {
            await _apiService.Consume(5);

            DataResponse<Manga> responseMangas = await _mangaService.GetSix();

            if (!responseMangas.HasSuccess)
            {
                //Se o select falhou, retorne a mensagem de erro para o cliente
                ViewBag.Errors = responseMangas.Message;
                return View();
            }
            //Se chegou aqui, o select funcionou, bora transformar a List<Pet> em uma List<PetSelectViewModel>


            List<MangaSelectCatalogViewModel> mangas =
                _mapper.Map<List<MangaSelectCatalogViewModel>>(responseMangas.Data);

            return View(mangas);
        }

        public IActionResult Privacy()
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