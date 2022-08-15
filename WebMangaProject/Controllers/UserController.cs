using AutoMapper;
using BusinessLogicalLayer.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using MvcPresentationLayer.Models;
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
    }
}
