using DataAccessLayer.Interfaces.IUSerInterfaces;
using Shared.Responses;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserDAL UserRepository { get; }

        Task<Response> Commit();
        Task<Response> CommitForUser();
    }
}
