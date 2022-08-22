﻿using AutoMapper;
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
        private readonly string _filePath; 

        public UserController(IUserService userService, IMapper mapper, IWebHostEnvironment env)
        {
            this._filePath = env.WebRootPath;
            this._userService = userService;
            this._mapper = mapper;
        }

        public string SaveFile(IFormFile file)
        {
            var name = Guid.NewGuid().ToString() + file.FileName;

            var filePath = _filePath + "//pics";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            using (var stream = System.IO.File.Create(filePath + "//" + name))
            {
                file.CopyToAsync(stream);
            }
            return name;
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
            if (id != userUpdate.Id)
            {
                return NotFound();
            }

            var userSelectResponse = await _userService.Select(id);


            User user = userSelectResponse.Data;
            user.Nickname = userUpdate.Nickname;
            user.About = userUpdate.About;


            string name = _filePath + @"\pics\" + SaveFile(fileF);
            byte[] image;
            using (var stream = new FileStream(name, FileMode.Open, FileAccess.Read))
            {
                using(var reader = new BinaryReader(stream))
                {
                    image = reader.ReadBytes((int)stream.Length);
                }
            }
            user.AvatarImage = image;

            var response = await _userService.Update(user);

            if (response.HasSuccess)
                return RedirectToAction("Index");

            ViewBag.Errors = response.Message;
            return View(userUpdate);
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

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> UserExists(int id)
        {
            var userSelectResponse = await _userService.Select(id);
            return userSelectResponse.HasSuccess;            
        }
    }
}
