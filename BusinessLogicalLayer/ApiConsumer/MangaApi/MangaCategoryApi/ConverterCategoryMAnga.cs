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
                c.ID = Convert.ToInt32(item.id);
                c.Name = item.attributes.title;
                c.Description = item.attributes.description;
                category.Add(c);
            }


            return category;
        }
    }
}
