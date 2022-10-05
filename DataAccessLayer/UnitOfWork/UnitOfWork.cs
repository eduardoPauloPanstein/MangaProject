using DataAccessLayer.Implementations;
using DataAccessLayer.Interfaces.IUSerInterfaces;
using Shared;
using Shared.Responses;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MangaProjectDbContext _dbContext;
        private IUserDAL userRepository = null;

        public UnitOfWork(MangaProjectDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        //public async Task Commit() => _ = await _dbContext.SaveChangesAsync();

        public async Task<Response> Commit()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return ResponseFactory.CreateInstance().CreateFailedResponse(ex);
            }
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
