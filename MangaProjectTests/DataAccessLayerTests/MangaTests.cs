using DataAccessLayer;
using DataAccessLayer.Implementations;
using Microsoft.EntityFrameworkCore;

namespace MangaProjectTests.DataAccessLayerTests
{
    public class MangaTests
    {
        [Fact]
        public void GetByFavorites_ReturnNotNull()
        {
            using (var context = new MangaProjectDbContext())
            {
               MangaDAL m = new(context);

                // Act  
                var mangas = m.GetByFavorites(0, 100);

                //Assert  
                Assert.NotNull(mangas);

            }

        }
    }
}
