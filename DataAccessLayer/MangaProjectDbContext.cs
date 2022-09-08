using Entities.MangaS;
using Entities.UserS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MangaProjectDbContext : DbContext
    {
        //SQL para a tabela a partir dessa propriedade.
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<User> Users { get; set; }
        public MangaProjectDbContext(DbContextOptions options) : base(options) { }
        public MangaProjectDbContext()
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Definição de connection string e connection resiliance (se a conexão cair, tenta se reconectar até 5 vezes)
        //    optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\paulo\Documents\MangaProjectDB.mdf;Integrated Security=True;Connect Timeout=30", options => options.EnableRetryOnFailure(5));
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assembly no contexto do .NET
            //Carrega os map config que tão criado dentro do projeto (assembly) DAL
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);

        }
    }
}
