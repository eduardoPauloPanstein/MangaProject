namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private MangaProjectDbContext context;
        public UnitOfWork(MangaProjectDbContext context)
        {
            this.context = context;
            Address = new AddressRepository(this.context);
            Email = new EmailRepository(this.context);
            Person = new PersonRepository(this.context);
        }
        public IAdressRepository Address
        {
            get;
            private set;
        }
        public IEmailRepository Email
        {
            get;
            private set;
        }
        public IPersonRepository Person
        {
            get;
            private set;
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
