using Entities.UserS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IUSerInterfaces
{
    public interface IUserPost
    {
        Task<Response> AddUserMangaItem(UserMangaItem item,int score);
        Task<Response> AddUserAnimeItem(UserAnimeItem item,int score);

    }
}
