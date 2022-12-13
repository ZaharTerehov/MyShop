using MyShop.Interfaces;
using MyShop.Models;

namespace MyShop.Services
{
    public class LocalCatalogItemRepository : IRepository<CatalogItem>
    {
        private static List<CatalogItem> _catalogItems = new List<CatalogItem>
            {
                new (1, ".net bot black sweatshirt", ".net bot black sweatshirt", 19.5m,  "/images/products/1.png"),
                new (2, ".net black & white mug", ".net black & white mug", 8.50m, "/images/products/2.png"),
                new (3, "prism white t-shirt", "prism white t-shirt", 12,  "/images/products/3.png"),
                new (4, ".net foundation sweatshirt", ".net foundation sweatshirt", 12, "/images/products/4.png"),
                new (5,"roslyn redsheet", "roslyn red sheet", 8.5m, "/images/products/5.png"),
                new (6, ".net blue sweatshirt", ".net blue sweatshirt", 12, "/images/products/6.png"),
                new (7, "roslyn red t-shirt", "roslyn red t-shirt",  12, "/images/products/7.png"),
                new (8, "kudu purple sweatshirt", "kudu purple sweatshirt", 8.5m, "/images/products/8.png"),
                new (9,  "cup<t> white mug", "cup<t> white mug", 12, "/images/products/9.png"),
                new (10, ".net foundation sheet", ".net foundation sheet", 12, "/images/products/10.png"),
                new (11, "cup<t> sheet", "cup<t> sheet", 8.5m, "/images/products/11.png"),
                new (12, "prism white tshirt", "prism white tshirt", 12, "/images/products/12.png")
            };

        public LocalCatalogItemRepository()
        {

        }

        public List<CatalogItem> GetAll()
        {
            return _catalogItems;
        }

        public CatalogItem? GetById(int id)
        {
            var item = _catalogItems.FirstOrDefault(x => x.Id == id);

            return item;
        }

        public void Update(CatalogItem entity)
        {
            var existingItem = GetById(entity.Id);

            if(existingItem != null)
            {
                var index = _catalogItems.IndexOf(existingItem);
                _catalogItems[index] = entity;
            }
        }
    }
}
