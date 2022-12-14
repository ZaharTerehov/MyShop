using MyShop.ApplicationCore.Interfaces;
using MyShop.Interfaces;
using MyShop.Models;
using MyShop.Models.ViewModel;
using NuGet.Protocol.Core.Types;

namespace MyShop.Services
{
    public class CatalogItemViewModelService : ICatalogItemViewModelService
    {
        private readonly IRepository<CatalogItem> _catalogItemRepositiry;
        private readonly IAppLogger<CatalogItemViewModelService> _logger;

        public CatalogItemViewModelService(IRepository<CatalogItem> catalogItemRepositiry,
            IAppLogger<CatalogItemViewModelService> logger)
        {
            _catalogItemRepositiry = catalogItemRepositiry;
            _logger = logger;
        }

        public void UpdateCatalogItem(CatalogItemViewModel viewModel)
        {
            var existingCatalogItem = _catalogItemRepositiry.GetById(viewModel.Id);

            if(existingCatalogItem is null)
            {
                var exception = new Exception($"Catalog item{viewModel.Id} was not found");
                _logger.LogError(exception, exception.Message, this);

                throw exception;
            }

            CatalogItem.CatalogItemDetails details = new(viewModel.Name, viewModel.Price);
            existingCatalogItem.UpdateDetails(details);

            _logger.LogInformation($"Updating catalog item {existingCatalogItem.Id}. Name {existingCatalogItem.Name}. Price {existingCatalogItem.Price}");

            _catalogItemRepositiry.Update(existingCatalogItem);
        }
    }
}
