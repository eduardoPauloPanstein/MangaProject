using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IUsualGetInterfaces<T>
    {
        Task<DataResponse<T>> GetByUserCount(int skip, int take);
        Task<DataResponse<T>> GetByFavorites(int skip, int take);
        Task<DataResponse<T>> GetByRating(int skip, int take);
        Task<DataResponse<T>> Get(string name);
        Task<int> GetLastIndexCategory();
        Task<int> GetLastIndex();
    }
}
