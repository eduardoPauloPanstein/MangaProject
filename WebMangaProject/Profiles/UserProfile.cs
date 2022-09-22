using AutoMapper;
using Entities.UserS;
using MvcPresentationLayer.Models.AnimeModel;
using MvcPresentationLayer.Models.MangaModels;
using MvcPresentationLayer.Models.User;
using MvcPresentationLayer.Models.UserModel;

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


			CreateMap<UserProfileViewModel, User>();
			CreateMap<User, UserProfileViewModel>();

			CreateMap<UserFavoriteMangaViewModel, UserMangaItem>();
            CreateMap<UserFavoriteAnimeViewModel, UserAnimeItem>();


        }
    }
}
