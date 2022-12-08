using MyShop.Interfaces;
using MyShop.Models;
using MyShop.Models.ViewModel;

namespace MyShop.Services
{
    public class CatalogItemViewModelService : ICatalogItemViewModelService
    {
        private readonly IRepository<CatalogItem> _catalogItemRepositiry;
        
        public CatalogItemViewModelService()
        {
            _catalogItemRepositiry = new LocalCatalogItemRepository();
        }
        public void UpdateCatalogItem(CatalogItemViewModel viewModel)
        {
            var existingCatalogItem = _catalogItemRepositiry.GetById(viewModel.Id);

            if(existingCatalogItem is null)
            {
                throw new Exception($"Catalog item{viewModel.Id} was not found");
            }

            CatalogItem.CatalogItemDetails details = new(viewModel.Name, viewModel.Price);
            existingCatalogItem.UpdateDetails(details);
            _catalogItemRepositiry.Update(existingCatalogItem);
        }
    }
}
