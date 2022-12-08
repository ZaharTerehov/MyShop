using MyShop.Interfaces;
using MyShop.Models;

namespace MyShop.Services
{
    public class LocalCatalogItemRepository : IRepository<CatalogItem>
    {
        private static List<CatalogItem> _catalogItems = new List<CatalogItem>
            {
                new (Guid.NewGuid(), ".net bot black sweatshirt", ".net bot black sweatshirt", 19.5m,  "/images/products/1.png"),
                new (Guid.NewGuid(), ".net black & white mug", ".net black & white mug", 8.50m, "/images/products/2.png"),
                new (Guid.NewGuid(), "prism white t-shirt", "prism white t-shirt", 12,  "/images/products/3.png"),
                new (Guid.NewGuid(), ".net foundation sweatshirt", ".net foundation sweatshirt", 12, "/images/products/4.png"),
                new (Guid.NewGuid(),"roslyn redsheet", "roslyn red sheet", 8.5m, "/images/products/5.png"),
                new (Guid.NewGuid(), ".net blue sweatshirt", ".net blue sweatshirt", 12, "/images/products/6.png"),
                new (Guid.NewGuid(), "roslyn red t-shirt", "roslyn red t-shirt",  12, "/images/products/7.png"),
                new (Guid.NewGuid(), "kudu purple sweatshirt", "kudu purple sweatshirt", 8.5m, "/images/products/8.png"),
                new (Guid.NewGuid(),  "cup<t> white mug", "cup<t> white mug", 12, "/images/products/9.png"),
                new (Guid.NewGuid(), ".net foundation sheet", ".net foundation sheet", 12, "/images/products/10.png"),
                new (Guid.NewGuid(), "cup<t> sheet", "cup<t> sheet", 8.5m, "/images/products/11.png"),
                new (Guid.NewGuid(), "prism white tshirt", "prism white tshirt", 12, "/images/products/12.png")
            };

        public List<CatalogItem> GetAll()
        {
            return _catalogItems;
        }

        public CatalogItem? GetById(Guid id)
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
