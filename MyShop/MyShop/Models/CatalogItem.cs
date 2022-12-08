namespace MyShop.Models
{
    public sealed class CatalogItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public CatalogType? CatalogType { get; set; }

        public CatalogBrand CatalogBrand { get; set; }

        public CatalogItem(Guid id, string name, string description, decimal price, string pictureUrl)
        {
            id = Guid.NewGuid();
            Name = name;
            //Description = description;
            Price = price;
            PictureUrl = pictureUrl;
        }

        public void UpdateDetails(CatalogItemDetails details)
        {
            Name = details.Name;
            //Description = details.Description;
            Price = details.Price;
        }

        public readonly record struct CatalogItemDetails
        {
            public string? Name { get; }
            //public string? Description { get; }
            public decimal Price { get; }

            public CatalogItemDetails(string name, decimal price)
            {
                Name = name;
                Price = price;
            }
        }
    }
}
