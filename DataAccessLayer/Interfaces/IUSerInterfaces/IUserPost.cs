using Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces.IUSerInterfaces
{
    public interface IUserPost
    {
        Task<Response> FavoriteManga(int idmanga, int idusuario);
    }
}
