using Entities.MangaS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.ApiConsumer.CategoryApi
{
    internal interface ICategoryApiConnect
    {
        Task<DataResponse<Category>> CovertiCatego(RootCate Cate);
        Task<Response> DeleteAllDatas();
    }
}
