namespace MyShop.ApplicationCore.Entities
{
    public class CatalogBrand
    {
        public int Id { get; set; }

        public string? Brand { get; set; }

        public CatalogBrand(string brand)
        {
            Brand = brand;
        }
    }
}
