﻿namespace MvcPresentationLayer.Models.User
{
    public class UserInsertViewModel
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}