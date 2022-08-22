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

        public UserController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
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
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nickname,About,CoverImageLink,AvatarImageLink")] UserUpdateViewModel userUpdate)
        {
            if (id != userUpdate.Id)
            {
                return NotFound();
            }

            var userSelectResponse = await _userService.Select(id);
            User user = userSelectResponse.Data;
            user.Nickname = userUpdate.Nickname;
            user.About = userUpdate.About;


            var response = await _userService.Update(user);

            if (response.HasSuccess)
                return RedirectToAction("Index");

            ViewBag.Errors = response.Message;
            return View(userUpdate);
        }

        [HttpPost, ActionName("Delete")]
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
