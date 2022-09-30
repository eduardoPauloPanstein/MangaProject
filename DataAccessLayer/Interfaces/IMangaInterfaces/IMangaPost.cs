using Entities;
using Entities.MangaS;
using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IMangaInterfaces
{
    public interface IMangaPost
    {
        Task<Response> DeleteAllDatas();
        Task<Response> InsertCategory(Category id);
        Task<Response> LeaveComentary(MangaComentary Leave);
    }
}
