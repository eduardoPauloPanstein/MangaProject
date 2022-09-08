using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities.UserS;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
                return BadRequest(responseUsers);
            }

            return Ok(responseUsers);
        }

        // GET api/User/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var responseUsers = await _userService.Select(id);
            if (!responseUsers.HasSuccess)
            {
                return BadRequest(responseUsers);
            }

            return Ok(responseUsers);
        }



        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] string value)
        {
            var user = JsonConvert.DeserializeObject<User>(value);

            var response = await _userService.Insert(user);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] string value)
        {
            var user = JsonConvert.DeserializeObject<User>(value);

            var response = await _userService.Update(user);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _userService.Delete(id);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] string value)
        {
            var user = JsonConvert.DeserializeObject<UserLogin>(value);

            var response = await _userService.Login(user);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
