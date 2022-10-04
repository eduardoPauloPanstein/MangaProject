using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces.IUSerInterfaces;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MangaProjectDbContext _dbContext;
        private IUserDAL? userRepository = null;

        public UnitOfWork()
        {
            _dbContext = new MangaProjectDbContext();
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
        public IUserDAL UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserDAL(_dbContext);
                }
                return userRepository;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
