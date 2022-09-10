using AutoMapper;
using Entities.Enums;
using Entities.UserS;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Apis.MangaProjectApi;
using MvcPresentationLayer.Models.User;
using MvcPresentationLayer.Models.UserModel;
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


        public async Task<IActionResult> Index()
        {
            DataResponse<User> responseUsers = await _userApiService.Select();
            if (!responseUsers.HasSuccess)
            {
                return BadRequest(responseUsers.Exception);
            }
            List<UserSelectViewModel> users =
                _mapper.Map<List<UserSelectViewModel>>(responseUsers.Data);
            return View(users);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
                _ = AuthenticationAsync(response.Data);
                return RedirectToAction("Index", "Home");

            }

            ViewBag.Errors = response.Message;
            return View();
        }

        [Authorize(Policy = "User")]
        public IActionResult TesteAuth() => Ok(User.Claims.Select(x => new { Type = x.Type, Value = x.Value }));

        public async Task AuthenticationAsync(User user)
        {
            ClaimsIdentity identity = new ("CookieSerieAuth");

            identity.AddClaim(new Claim(ClaimTypes.Name, user.Nickname));
            identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
            identity.AddClaim(new Claim(ClaimTypes.Role, Enum.GetName(typeof(UserRoles), user.Role)));


            ClaimsPrincipal principal = new (identity);

            await HttpContext.SignInAsync("CookieSerieAuth", principal);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserInsertViewModel viewModel)
        {
            User user = _mapper.Map<User>(viewModel);
            var response = await _userApiService.Insert(user);

            if (response.HasSuccess)
                return RedirectToAction("Index");

            ViewBag.Errors = response.Message;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var userSelectResponse = await _userApiService.Select(id);

            if (!userSelectResponse.HasSuccess)
            {
                return NotFound();
            }
            User user = userSelectResponse.Data;
            UserUpdateViewModel userUpdate = _mapper.Map<UserUpdateViewModel>(user);


            return View(userUpdate);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
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

            response = await _userApiService.Update(user);

            if (!response.HasSuccess)
            {
                ViewBag.Errors = response.Message;
                return View(userUpdate);
            }

            return RedirectToAction("Index", "Home");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await UserExists(id))
            {
                return Problem("User is null.");
            }

            await _userApiService.Delete(id);
            //Delete avatar

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UserExists(int id)
        {
            var userSelectResponse = await _userApiService.Select(id);
            return userSelectResponse.HasSuccess;            
        }
    }
}
