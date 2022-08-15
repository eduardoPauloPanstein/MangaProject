using AutoMapper;
using Entities;
using MvcPresentationLayer.Models;

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
            
        }
    }
}
