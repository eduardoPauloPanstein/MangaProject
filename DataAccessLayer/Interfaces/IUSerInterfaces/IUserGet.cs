using Entities.MangaS;
using Entities.UserS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IUSerInterfaces
{
    public interface IUserGet
    {
        Task<DataResponse<Manga>> GetUserList(int userid);
        Task<DataResponse<Manga>> GetUserFavorites(int userid);
    }
}
