using AutoMapper;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using Entities.UserS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared.Responses;
using WebApi.Services;

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
        [HttpGet(template:"skip/{skip}/take/{take}")]
        public async Task<IActionResult> GetAsync([FromRoute] int skip = 0, [FromRoute] int take = 25)
        {
            if (take >= 100)
            {
                return BadRequest("take < 100");
            }
            DataResponse<User> responseUsers = await _userService.Select(skip, take);
            if (!responseUsers.HasSuccess)
            {
                return BadRequest(responseUsers);
            }

            return Ok(responseUsers);
        }

        // GET api/User/5
        [HttpGet("{id}")]
        [Authorize]
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


        [HttpPost("LoginA")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync([FromBody] string value)
        {
            var user = JsonConvert.DeserializeObject<UserLogin>(value);

            //recuperar usuario
            var response = await _userService.Login(user);

            if (!response.HasSuccess)
            {
                return BadRequest(new SingleResponseWToken<User>(response.Message, response.HasSuccess, response.Data, null, null));
            }

            //Gerar token
            var token = TokenService.GenerateToken(response.Data);

            //testando
            SingleResponseWToken<User> responseWToken = new(response.Message, response.HasSuccess, response.Data, token, null);

            //Retornar user + token
            return Ok(responseWToken);
        }

        [HttpGet("Authenticated")]
        [Authorize]
        public string Authenticated() => String.Format($"Autenticado - {User.Identity.Name}");

        [HttpGet("AuthorizeUser")]
        [Authorize(Policy = "User")]
        public IActionResult TesteAuth() => Ok(User.Claims.Select(x => new { Type = x.Type, Value = x.Value }));
    }
}
