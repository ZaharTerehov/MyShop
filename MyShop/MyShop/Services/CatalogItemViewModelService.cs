using MyShop.Interfaces;
using MyShop.Models;
using MyShop.Models.ViewModel;
using NuGet.Protocol.Core.Types;

namespace MyShop.Services
{
    public class CatalogItemViewModelService : ICatalogItemViewModelService
    {
        private readonly IRepository<CatalogItem> _catalogItemRepositiry;
        
        public CatalogItemViewModelService(IRepository<CatalogItem> catalogItemRepositiry)
        {
            _catalogItemRepositiry = catalogItemRepositiry;
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
