using MyShop.ApplicationCore.Entities;

namespace MyShop.Models
{
    public sealed class CatalogItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public CatalogType? CatalogType { get; set; }

        public CatalogBrand CatalogBrand { get; set; }
        public int CatalogTypeId { get; }
        public int CatalogBrandId { get; }
        public string Pict { get; }

        public CatalogItem(int id, string name, string v, decimal price, string pictureUrl)
        {
            Id = id;
            Name = name;
            Price = price;
            PictureUrl = pictureUrl;
        }

        public CatalogItem(int catalogTypeId,
        int catalogBrandId,
        string description,
        string name,
        decimal price,
        string pictureUri)
        {
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrandId;
            //Description = description;
            Name = name;
            Price = price;
            Pict = pictureUri;
        }

        public void UpdateDetails(CatalogItemDetails details)
        {
            Name = details.Name;
            Price = details.Price;
        }

        public readonly record struct CatalogItemDetails
        {
            public string? Name { get; }
            public decimal Price { get; }

            public CatalogItemDetails(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
        }
    }
}
