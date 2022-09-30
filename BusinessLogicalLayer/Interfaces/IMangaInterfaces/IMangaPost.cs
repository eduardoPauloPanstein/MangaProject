using Entities;
using Entities.MangaS;
using Shared.Responses;

namespace BusinessLogicalLayer.Interfaces.IMangaInterfaces
{
    public interface IMangaPost
    {
        Task<Response> InsertCategory(Category id);
        Task<Response> InsertComentary(MangaComentary Leave);
        Task<Response> DeleteComentary(int Id);

    }
}
