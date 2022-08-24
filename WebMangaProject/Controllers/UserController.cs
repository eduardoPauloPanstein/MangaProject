using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Models.User;
using Shared;

namespace MvcPresentationLayer.Controllers
{
    
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private string _filePath;

        public UserController(IUserService userService, IMapper mapper, IWebHostEnvironment env)
        {
            this._filePath = env.WebRootPath;
            this._userService = userService;
            this._mapper = mapper;
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
            DataResponse<User> responseUsers = await _userService.SelectAll();
            if (!responseUsers.HasSuccess)
            {
                ViewBag.Erros = responseUsers.Message;
                return View();
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
            User user = _mapper.Map<User>(userLoginView);
            var response = await _userService.Login(user);

            if (response.HasSuccess)
                return RedirectToPage("Home");

            ViewBag.Errors = response.Message;
            return View();
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
            var response = await _userService.Insert(user);

            if (response.HasSuccess)
                return RedirectToAction("Index");

            ViewBag.Errors = response.Message;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var userSelectResponse = await _userService.Select(id);

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

            response = await _userService.Update(user);

            if (!response.HasSuccess)
            {
                ViewBag.Errors = response.Message;
                return View(userUpdate);
            }
            
            return RedirectToAction("Edit");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await UserExists(id))
            {
                return Problem("User is null.");
            }

            await _userService.Delete(id);
            //Delete avatar

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UserExists(int id)
        {
            var userSelectResponse = await _userService.Select(id);
            return userSelectResponse.HasSuccess;            
        }
    }
}
