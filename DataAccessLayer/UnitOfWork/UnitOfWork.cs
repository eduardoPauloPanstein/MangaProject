using DataAccessLayer.ErrorHandling;
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

        public UnitOfWork(MangaProjectDbContext dbContext, IUserDAL userDAL)
        {
            this._dbContext = dbContext;
        }

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
        public async Task<Response> CommitForUser()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return ResponseFactory.CreateInstance().CreateSuccessResponse();
            }
            catch (Exception ex)
            {
                return UserDbFailed.Handle(ex);
            }
        }


        private bool disposed = false;

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
