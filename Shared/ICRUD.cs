using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface ICRUD<T>
    {
        Task<Response> Insert(T Item);
        Task<SingleResponse<T>> Select(int id);
        Task<DataResponse<T>> Select(int skip, int take);
        Task<Response> Update(T Item);
        Task<Response> Delete(int id);
    }
}
