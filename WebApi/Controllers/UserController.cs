using AutoMapper;
using BusinessLogicalLayer.Interfaces.IUserInterfaces;
using Entities.Enums;
using Entities.UserS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shared;
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
            _userService.CreateAdmin();
        }

        /// <summary>
        /// Pegar usuarios atravez da paginação
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        [HttpGet(template:"skip/{skip}/take/{take}"), Authorize]
        public async Task<IActionResult> GetAsync([FromRoute] int skip = 0, [FromRoute] int take = 25)
        {
            if (take >= 100)
            {
                return BadRequest("take < 100");
            }
            DataResponse<User> responseUsers = await _userService.Get(skip, take);
            if (!responseUsers.HasSuccess)
            {
                return BadRequest(responseUsers);
            }

            return Ok(responseUsers);
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetAsync(int id)
        {
            var responseUsers = await _userService.Get(id);
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

            var user = JsonConvert.DeserializeObject<User>(value);

            var response = await _userService.Insert(user);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> PutAsync(int id, [FromBody] string value)
        {
            if (!UserService.IsAdmin(HttpContext))
            {
                if (!UserService.IsAmMyself(HttpContext, id))
                    return BadRequest();
            }
           

            var user = JsonConvert.DeserializeObject<User>(value);

            var response = await _userService.Update(user);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            //only admin or the logged in user
            if (!UserService.IsAdmin(HttpContext))
            {
                if (!UserService.IsAmMyself(HttpContext, id))
                    return BadRequest();
            }

            var response = await _userService.Delete(id);
            if (!response.HasSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPost("Authenticate"), AllowAnonymous]
        public async Task<IActionResult> AuthenticateAsync(UserLogin user)
        {
            //mvc need a SingleResponseWToken return 

            if (UserService.IsAuthenticated(HttpContext))
                return BadRequest("User is authenticated");

            //var user = JsonConvert.DeserializeObject<UserLogin>(value);

            var response = await _userService.Login(user);

            if (!response.HasSuccess)
            {

                if (response.IsInfrastructureError)
                    return BadRequest(response.Exception);
                //return BadRequest(ResponseFactory.CreateInstance().CreateFailedSingleResponseWToken<User>(response.Message));
                else
                    return Unauthorized();
            }

            var token = TokenService.GenerateToken(response.Item);

            return Ok(ResponseFactory.CreateInstance().CreateSuccessSingleResponseWToken(token, response.Item));
        }

    }
}
