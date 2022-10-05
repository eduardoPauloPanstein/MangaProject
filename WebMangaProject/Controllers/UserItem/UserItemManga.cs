using AutoMapper;
using Entities.UserS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi.UserItem.UserMangaItem;
using Shared.Responses;
namespace MvcPresentationLayer.Controllers.UserItem
{
    public class UserItemManga : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiMangaItem _MangaItem;
        public UserItemManga(IMapper mapper, IMangaProjectApiMangaItem Mangaitem)
        {
            this._MangaItem = Mangaitem;
            this._mapper = mapper;
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Insert(UserMangaItem fav)
        {
            Response Response = await _MangaItem.Insert(fav, null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("AnimeOnPage", "Anime", new { id = fav.Id });
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Update(UserMangaItem fav)
        {
            Response Response = await _MangaItem.Update(fav, null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("AnimeOnPage", "Anime", new { id = fav.Id });
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Get(int id)
        {
            SingleResponse<UserMangaItem> Response = await _MangaItem.Get(id, null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("AnimeOnPage", "Anime", new { id = id });
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Get(int skp, int take)
        {
            DataResponse<UserMangaItem> Response = await _MangaItem.Get(skp, take,null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("Home", "Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            Response Response = await _MangaItem.Delete(id, null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> GetByUser(int id)
        {
            Response Response = await _MangaItem.GetByUser(id,null);
            if (!Response.HasSuccess)
            {
                return BadRequest(Response);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
