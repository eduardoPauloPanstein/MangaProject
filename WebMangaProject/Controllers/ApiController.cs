using ApiConsumer;
using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities.Manga;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Models.Manga;
using Shared;

namespace MvcPresentationLayer.Controllers
{
    public class ApiController : Controller
    {
        private readonly IMangaService _mangaService;
        private readonly IMapper _mapper;
        private readonly IApiConnect _apiService;

        public ApiController(IMangaService svc, IMapper mapper, IApiConnect apiConnect)
        {
            this._mapper = mapper;
            this._mangaService = svc;
            this._apiService = apiConnect;
        }

        public async Task<IActionResult> Index()
        {
            DataResponse<Manga> responseMangas = await _apiService.Consume(20);

            if (!responseMangas.HasSuccess)
            {
                //Se o select falhou, retorne a mensagem de erro para o cliente
                ViewBag.Errors = responseMangas.Message;
                return View();
            }

            //List<MangaSelectCatalogViewModel> mangasCatalogView =
            //    _mapper.Map<List<MangaSelectCatalogViewModel>>(responseMangas.Data);

            return View(responseMangas.Data);
        }
    }
}
