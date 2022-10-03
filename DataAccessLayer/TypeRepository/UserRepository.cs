using DataAccessLayer.Implementations;

namespace DataAccessLayer.TypeRepository
{

    class UserRepository : UserDAL
    {
        public UserRepository(MangaProjectDbContext context) : base(context) { }
    }
}
