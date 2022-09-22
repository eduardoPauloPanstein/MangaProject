using DataAccessLayer;
using DataAccessLayer.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaProjectTests.DataAccessLayerTests
{
    public class UserTests : IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvider;

        public UserTests(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void GetUser_ReturnNotNull()
        {
            using (var context = _serviceProvider.GetService<MangaProjectDbContext>())
            {
                UserDAL u = new(context);

                // Act  
                var response = u.Get(1);
                var user = response.Result.Data;

                //Assert  
                Assert.NotNull(user);
            }

        }
    }
}
