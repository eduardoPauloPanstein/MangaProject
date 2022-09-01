using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        // todo paginação
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            DataResponse<User> responseUsers = await _userService.SelectAll();
            if (!responseUsers.HasSuccess)
            {
                return BadRequest();
            }

            return Ok(responseUsers.Data);
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
