using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsumer
{
    public interface IApiConnect
    {
        /// <summary>
        /// Consome mangas da API exerna kitsu, e insere na DB(DAL)
        /// </summary>
        /// <param name="qtdMangas"></param>
        /// <returns></returns>
        Task<DataResponse<Response>> Consume(int qtdMangas);
        Task<Response> DeleteAllDatas();

    }
}
