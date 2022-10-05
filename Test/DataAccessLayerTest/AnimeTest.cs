using DataAccessLayer;
using DataAccessLayer.Implementations;
using Entities.AnimeS;
using Entities.UserS;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DataAccessLayerTest
{
    public class AnimeTest : IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvider;

        public AnimeTest(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void GetAnime_ReturnNotNull()
        {
            //using (var context = _serviceProvider.GetService<MangaProjectDbContext>())
            //{
            //    AnimeDAL dal = new(context);
            //    AnimeComentary a = new();
            //    a.DataComentary = DateTime.Now;
            //    a.Comentary = "One shit";


            //    // Act  
            //    var response = dal.LeaveComentary(a);



            //    //var user = response.Result.Data;

            //    //Assert  
            //    Assert.NotNull(a);
            //}

        }
    }
}
