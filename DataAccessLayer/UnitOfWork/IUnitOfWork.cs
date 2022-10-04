using DataAccessLayer.Interfaces.IUSerInterfaces;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserDAL UserRepository { get; }

        void Commit();
    }
}
