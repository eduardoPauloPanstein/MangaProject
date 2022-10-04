﻿using BusinessLogicalLayer.Interfaces.IUserItemService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Entities.MangaS;
using Entities.UserS;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeItemController : ControllerBase
    {
        private readonly IUserAnimeItemService _AnimeItem;

        public AnimeItemController(IUserAnimeItemService AnimeItem)
        {
            this._AnimeItem = AnimeItem;
        }

        [HttpGet(template: "skip/{skip}/take/{take}"), AllowAnonymous]
        public async Task<IActionResult> GetAsync([FromRoute] int skip = 0, [FromRoute] int take = 25)
        {
            if (take >= 100)
            {
                return BadRequest("take < 100");
            }
            var responseUsers = await _AnimeItem.Get(skip, take);
            if (!responseUsers.HasSuccess)
            {
                return BadRequest(responseUsers);
            }

            return Ok(responseUsers);
        }

        [HttpGet("ById/{id}"), AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var responseUsers = await _AnimeItem.Get(id);
            if (!responseUsers.HasSuccess)
            {
                return BadRequest(responseUsers);
            }

            return Ok(responseUsers);
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] string value)
        {
            //if (IsAuthenticated())

            var manga = JsonConvert.DeserializeObject<UserAnimeItem>(value);

            var response = await _AnimeItem.Insert(manga);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("{id}"), AllowAnonymous]
        public async Task<IActionResult> PutAsync(int id, [FromBody] string value)
        {
            var user = JsonConvert.DeserializeObject<UserAnimeItem>(value);

            var response = await _AnimeItem.Update(user);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}"), AllowAnonymous]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _AnimeItem.Delete(id);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
