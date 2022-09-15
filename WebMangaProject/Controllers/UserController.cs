using AutoMapper;
using Entities.Enums;
using Entities.UserS;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi;
using MvcPresentationLayer.Models.User;
using MvcPresentationLayer.Models.UserModel;
using MvcPresentationLayer.Utilities;
using Shared;
using Shared.Responses;
using System.Security.Claims;

namespace MvcPresentationLayer.Controllers
{

    public class UserController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMangaProjectApiUserService _userApiService;
        private string _filePath;

        public UserController(IMapper mapper, IWebHostEnvironment env, IMangaProjectApiUserService userApiService)
        {
            this._filePath = env.WebRootPath;
            this._mapper = mapper;
            this._userApiService = userApiService;
        }

        [HttpGet, Authorize(Policy = "Admin")]
        public async Task<IActionResult> Index()
        {
            DataResponse<User> responseUsers = await _userApiService.Select(UserService.GetToken(HttpContext));
            if (!responseUsers.HasSuccess)
            {
                return BadRequest(responseUsers.Exception);
            }
            List<UserSelectViewModel> users =
                _mapper.Map<List<UserSelectViewModel>>(responseUsers.Data);
            return View(users);
        }

        #region Avatar
        public async Task<Response> SaveAvatarFileAsync(IFormFile file, User user)
        {
            var response = ImageFileValidator(file);
            if (!response.HasSuccess)
                return response;

            //var name = Guid.NewGuid().ToString() + file.FileName;
            string folder = "\\avatars";
            string filePath = _filePath + folder;
            string extension = Path.GetExtension(file.FileName);

            if (!Directory.Exists(filePath)) 
            {
                Directory.CreateDirectory(filePath); //folder
            }

            string name = $"{user.Nickname}Avatar{extension}";

            DeleteAvatarImage(folder, name);
            using (var stream = System.IO.File.Create(filePath + "\\" + name)) 
            {
                await file.CopyToAsync(stream);
            }

            user.AvatarImageFileLocation = name;

            return ResponseFactory.CreateInstance().CreateSuccessResponse();
        }
        public Response ImageFileValidator(IFormFile file)
        {
            switch (file.ContentType)
            {
                case "image/jpeg": return ResponseFactory.CreateInstance().CreateSuccessResponse();
                case "image/bmp": return ResponseFactory.CreateInstance().CreateSuccessResponse();
                case "image/gif": return ResponseFactory.CreateInstance().CreateSuccessResponse();
                case "image/png": return ResponseFactory.CreateInstance().CreateSuccessResponse();

                default:
                    return ResponseFactory.CreateInstance().CreateFailedResponse(null);
            }
        }
        public void DeleteAvatarImage(string folder, string fileName)
        {
            string filePath = $"{_filePath}{folder}\\{fileName}";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }
        #endregion

        #region Utilities

        public bool IsAuthenticated()
        {
            return HttpContext.User.Identity.IsAuthenticated;
        }
        public RedirectToActionResult RedirectIfIsAuthenticated()
        {
            return RedirectToAction("Index", "Home");
        }

        public bool IsAmMyself(int? id)
        {
            int MyId = UserService.GetId(HttpContext);
            return MyId == id;
        }
        public RedirectToActionResult RedirectIfImNotMe()
        {
            return RedirectToAction("Index", "Home");
        }

        public bool IsAdmin()
        {
            return UserService.IsRole(UserRoles.Admin.ToString(), HttpContext);
        }

        private async Task<bool> UserExists(int id)
        {
            var userSelectResponse = await _userApiService.Select(id, UserService.GetToken(HttpContext));
            return userSelectResponse.HasSuccess;
        }

        [Authorize]
        public IActionResult TesteAuth() => Ok(User.Claims.Select(x => new { Type = x.Type, Value = x.Value }));

        #endregion

        #region Login

        [HttpGet, AllowAnonymous]
        public IActionResult Login()
        {
            if (IsAuthenticated())
                return RedirectIfIsAuthenticated();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel userLoginView)
         {
            UserLogin login = new()
            {
                EmailOrNickname = userLoginView.EmailOrNickname,
                Password = userLoginView.Password
            };
            var response = await _userApiService.Login(login);

            if (response.HasSuccess)
            {
                _ = AuthenticationAsync(response.Data, response.Token);
                return RedirectToAction("Index", "Home");

            }

            ViewBag.Errors = response.Message;
            return View();
        }


        public async Task AuthenticationAsync(User user, string token)
        {
            ClaimsIdentity identity = new("CookieSerieAuth");

            identity.AddClaim(new Claim(ClaimTypes.Name, user.Nickname));
            identity.AddClaim(new Claim(ClaimTypes.PrimarySid, user.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Role.ToString()));
            identity.AddClaim(new Claim("Token", token));

            ClaimsPrincipal principal = new(identity);

            Thread.CurrentPrincipal = principal;

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddHours(8),
                IssuedUtc = DateTime.UtcNow
            };

            await HttpContext.SignInAsync("CookieSerieAuth", principal, authProperties);
        }

        public async Task LogoutAuthenticationAsync()
        {
            await HttpContext.SignOutAsync("CookieSerieAuth");
        }

        [HttpPost, ValidateAntiForgeryToken, Authorize] //Why not HttpDelete? 
        public async Task<IActionResult> logout()
        {
            await LogoutAuthenticationAsync();
            return RedirectToAction("Index", "Home");
        }

        #endregion


        [HttpGet, AllowAnonymous]
        public IActionResult Create()
        {
            if (IsAuthenticated())
                return RedirectIfIsAuthenticated();

            return View();
        }
        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<IActionResult> Create(UserInsertViewModel viewModel)
        {
            User user = _mapper.Map<User>(viewModel);

            var response = await _userApiService.Insert(user, UserService.GetToken(HttpContext));

            if (response.HasSuccess)
                return RedirectToAction("Index");

            ViewBag.Errors = response.Message;
            return View();
        }



        [HttpGet, Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!IsAmMyself(id))
                return RedirectIfImNotMe();

            var userSelectResponse = await _userApiService.Select(id, UserService.GetToken(HttpContext));

            if (!userSelectResponse.HasSuccess)
            {
                return NotFound();
            }
            User user = userSelectResponse.Data;
            UserUpdateViewModel userUpdate = _mapper.Map<UserUpdateViewModel>(user);

            return View(userUpdate);
        }
        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nickname,About,AvatarImage,CoverImage")] UserUpdateViewModel userUpdate, IFormFile fileF)
        {
            Response response;

            if (id != userUpdate.Id)
            {
                return NotFound();
            }

            User user = _mapper.Map<User>(userUpdate);
            
            if (fileF != null)
            {
                await SaveAvatarFileAsync(fileF, user);
            }

            response = await _userApiService.Update(user, UserService.GetToken(HttpContext));

            if (!response.HasSuccess)
            {
                ViewBag.Errors = response.Message;
                return View(userUpdate);
            }

            return RedirectToAction("Index", "Home");
        }



        [HttpPost, ValidateAntiForgeryToken, Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            //only admin or the logged in user
            if (!IsAdmin())
            {
                if (!IsAmMyself(id))
                    return RedirectIfImNotMe();
            }


            if (!await UserExists(id))
                return Problem("User is not exist.");


            await _userApiService.Delete(id, UserService.GetToken(HttpContext));
            //Delete avatar

            return RedirectToAction(nameof(Index));
        }

    }
}
