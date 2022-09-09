using Entities.UserS;
using Shared.Responses;

namespace BusinessLogicalLayer.Interfaces.IUserInterfaces
{
    public interface IUserGet
    {
        Task<DataResponse<UserMangaItem>> GetUserFavorites(int UserID);
    }
}
