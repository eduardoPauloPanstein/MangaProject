using Shared.Responses;

namespace Shared.Interfaces
{
    public interface IUsualGetInterfaces<T>
    {
        Task<DataResponse<T>> GetByUserCount(int skip, int take);
        Task<DataResponse<T>> GetByFavorites(int skip, int take);
        Task<DataResponse<T>> GetByRating(int skip, int take);
        Task<DataResponse<T>> GetByPopularity(int skip, int take);
        Task<DataResponse<T>> GetByCategory(int ID);
        Task<DataResponse<T>> Get(string name);
        Task<SingleResponse<T>> GetComplete(int ID);
        Task<int> GetLastIndexCategory();
        Task<int> GetLastIndex();
    }
}
