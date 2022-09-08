using ApiConsumer;
using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities.MangaS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Models.Manga;
using Shared.Responses;

namespace MvcPresentationLayer.Controllers
{
    public class MangaDbController : Controller
    {
        private readonly IMangaService _mangaSvc;
        private readonly IMapper _mapper;
        private readonly IApiConnect _apiService;

        public MangaDbController(IMangaService svc, IMapper mapper, IApiConnect connect)
        {
            this._mangaSvc = svc;
            this._mapper = mapper;
            this._apiService = connect;
        }
        //meusite.com/Pet
        //meusite.com/Pet/Index
        //ONCE YOU GO THREAD YOU NEVER GO BACK
        public async Task<IActionResult> Index()
        {
            DataResponse<Manga> responseMangas = await _mangaSvc.GetAll();

            if (!responseMangas.HasSuccess)
            {
                //Se o select falhou, retorne a mensagem de erro para o cliente
                ViewBag.Errors = responseMangas.Message;
                return View();
            }

            List<MangaShortDbViewModel> mangas =
                _mapper.Map<List<MangaShortDbViewModel>>(responseMangas.Data);

            return View(mangas);
        }
        public async Task<IActionResult> ConsumirApi()
        {
            await _apiService.DeleteAllDatas();
            DataResponse<Manga> responseMangas = await _apiService.Consume();

            if (!responseMangas.HasSuccess)
            {
                ViewBag.Errors = responseMangas.Message;
                return View();
            }
            return RedirectToAction("Index");
        }

        // GET: MangaDbController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MangaDbController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MangaDbController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MangaDbController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MangaDbController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MangaDbController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MangaDbController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
