using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities.MangaS;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Models.Manga;
using Shared.Responses;

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
        
        public async Task<IActionResult> MangaOnPage(int id)
        {
            SingleResponse<Manga> response = await _mangaService.GetByID(id);
            if (!response.HasSuccess)
            {
                return NotFound();
            }

            var manga = _mapper.Map<MangaOnPageViewModel>(response.Data);

            return View(manga);
        }
    }
}
