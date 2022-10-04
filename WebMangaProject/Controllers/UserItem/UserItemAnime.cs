using AutoMapper;
using Entities.AnimeS;
using Entities.UserS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi.ItemComentary.AnimeComentary;
using MvcPresentationLayer.Apis.MangaProjectApi.UserItem.UserAnimeItem;
using Shared.Responses;

namespace MvcPresentationLayer.Controllers.UserItem
{
    public class UserItemAnime : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiAnimeItem _AnimeItem;
        public UserItemAnime(IMapper mapper, IMangaProjectApiAnimeItem Animeitem)
        {
            this._AnimeItem = Animeitem;
            this._mapper = mapper;
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Insert(UserAnimeItem fav)
        {
            Response Response = await _AnimeItem.Insert(fav, null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("AnimeOnPage", "Anime", new { id = fav.Id });
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Update(UserAnimeItem fav)
        {
            Response Response = await _AnimeItem.Update(fav, null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("AnimeOnPage", "Anime", new { id = fav.Id });
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Get(int id)
        {
            SingleResponse<UserAnimeItem> Response = await _AnimeItem.Get(id, null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("AnimeOnPage", "Anime", new { id = id });
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Get(int skp, int take)
        {
            DataResponse<UserAnimeItem> Response = await _AnimeItem.Get(null, skp, take);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("Home", "Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            Response Response = await _AnimeItem.Delete(id, null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
