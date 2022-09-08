using BusinessLogicalLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private readonly IMangaService _mangaService;

        public MangaController(IMangaService mangaService)
        {
            this._mangaService = mangaService;
        }

        [HttpGet("GetSuggestionList/{title}")]
        public async Task<IActionResult> GetAsync([FromRoute] string title)
        {
            var response = await _mangaService.GetByName(title);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var responseUsers = await _mangaService.GetByID(id);
            if (!responseUsers.HasSuccess)
            {
                return BadRequest(responseUsers);
            }

            return Ok(responseUsers);
        }


    }
}
