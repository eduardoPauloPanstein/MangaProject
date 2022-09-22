using DataAccessLayer.Implementations;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangaProjectTests.DataAccessLayerTests
{
    public class UserTests
    {
        [Fact]
        public void GetByFavorites_ReturnNotNull()
        {
            using (var context = new MangaProjectDbContext())
            {
                UserDAL user = new(context);

                // Act  
                var u = user.Get(1);

                //Assert  
                //Assert.NotNull(mangas);

            }

        }
    }
}
