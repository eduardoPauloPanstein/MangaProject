using Entities.UserS;
using Shared.Responses;

namespace BusinessLogicalLayer.Interfaces.IUserInterfaces
{
    public interface IUserPost
    {
        Task<Response> FavoriteManga(UserMangaItem Fav);
    }
}
