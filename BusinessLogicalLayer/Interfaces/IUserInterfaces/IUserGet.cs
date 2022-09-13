using Entities.MangaS;
using Entities.UserS;
using Shared.Responses;

namespace BusinessLogicalLayer.Interfaces.IUserInterfaces
{
    public interface IUserGet
    {
        Task<DataResponse<Manga>> GetUserList(int userid);
        Task<DataResponse<Manga>> GetUserFavorites(int userid);
    }
}
