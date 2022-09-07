﻿using AutoMapper;
using Entities.UserS;
using MvcPresentationLayer.Models.User;

namespace MvcPresentationLayer.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserSelectViewModel, User>();
            CreateMap<User, UserSelectViewModel>();

            CreateMap<UserInsertViewModel, User>();
            CreateMap<User, UserInsertViewModel>();


            CreateMap<UserUpdateViewModel, User>();
            CreateMap<User, UserUpdateViewModel>();

            CreateMap<UserLoginViewModel, User>();
            CreateMap<User, UserLoginViewModel>();

        }
    }
}
