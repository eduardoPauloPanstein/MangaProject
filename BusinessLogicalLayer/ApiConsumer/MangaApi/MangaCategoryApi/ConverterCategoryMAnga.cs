using Entities.MangaS;

namespace BusinessLogicalLayer.ApiConsumer.MangaApi.MangaCategoryApi
{
    internal class ConverterCategoryMAnga
    {
        public static List<Category> CovertiMangaCate(RootMA Cate, int id)
        {
            List<Category> category = new();
            if (Cate.data == null)
            {
                return new List<Category>();
            }
            foreach (var item in Cate.data)
            {
                Category c = new Category();
                c.Name = item.attributes.title;
                c.Description = item.attributes.description;
                c.ApiID = Convert.ToInt32(item.id);
                category.Add(c);
            }


            return category;
        }
    }
}
