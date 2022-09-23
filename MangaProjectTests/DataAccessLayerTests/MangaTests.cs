using DataAccessLayer;
using DataAccessLayer.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MangaProjectTests.DataAccessLayerTests
{
    public class MangaTests : IClassFixture<DbFixture>
    {
        private ServiceProvider _serviceProvider;

        public MangaTests(DbFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
        }

        [Fact]
        public void GetByFavorites_ReturnNotNull()
        {
            using (var context = _serviceProvider.GetService<MangaProjectDbContext>())
            {
                MangaDAL m = new(context);

                // Act  
                var response = m.GetByFavorites(0, 100);
                var mangas = response.Result.Data;

                //Assert  
                Assert.NotNull(mangas);
            }

        }
    }
}
