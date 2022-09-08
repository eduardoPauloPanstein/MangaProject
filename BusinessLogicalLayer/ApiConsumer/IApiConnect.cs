using Entities.MangaS;
using Shared.Responses;
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
        /// <param></param>
        /// <returns></returns>
        Task<DataResponse<Manga>> Consume();
        Task<Response> DeleteAllDatas();

    }
}
