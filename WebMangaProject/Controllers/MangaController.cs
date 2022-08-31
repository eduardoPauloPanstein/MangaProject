using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities.Manga;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Models.Manga;
using Shared;

namespace MvcPresentationLayer.Controllers
{
    public class MangaController : Controller
    {
        private readonly IMangaService _mangaService;
        private readonly IMapper _mapper;


        public MangaController( IMangaService svc, IMapper mapper)
        {
            this._mapper = mapper;
            this._mangaService = svc;
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
    }
}
