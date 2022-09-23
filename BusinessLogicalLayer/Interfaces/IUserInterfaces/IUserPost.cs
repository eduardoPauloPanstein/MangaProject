using Entities.UserS;
using Shared.Responses;

namespace BusinessLogicalLayer.Interfaces.IUserInterfaces
{
    public interface IUserPost
    {
        Task<Response> AddUserMangaItem(UserMangaItem item);
        Task<Response> AddUserAnimeItem(UserAnimeItem item);

    }
}
