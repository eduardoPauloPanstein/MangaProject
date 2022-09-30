using DataAccessLayer;
using DataAccessLayer.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Test.DataAccessLayerTest
{
    public class UserTest : IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvider;

        public UserTest(DbFixture fixture)
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
                var user = response.Result.Item;

                //Assert  
                Assert.NotNull(user);
            }

        }

        [Fact]
        public void GetUserMangaList_ReturnNotNull()
        {
            using (var context = _serviceProvider.GetService<MangaProjectDbContext>())
            {
                UserDAL u = new(context);

                // Act  
                var response = u.Get(1);
                var user = response.Result.Item;
                var mangaList = user.MangaList;

                //Assert  
                Assert.NotNull(mangaList);
            }

        }
    }
}
