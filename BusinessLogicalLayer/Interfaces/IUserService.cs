﻿using Entities.UserS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IUserService
    {
        Task<Response> Insert(User user);
        Task<SingleResponse<User>> Select(int? id);
        Task<DataResponse<User>> Select(int skip, int take);
        Task<Response> Update(User user);
        Task<Response> Delete(int? id);
        Task<SingleResponse<User>> Login(UserLogin user);
        Task<DataResponse<UserMangaItem>> GetUserFavorites(int UserID);
        Task<Response> FavoriteManga(int idmanga, int idusuario);
    }
}
