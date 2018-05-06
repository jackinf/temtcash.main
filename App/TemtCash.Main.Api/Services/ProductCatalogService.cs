using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeysCloud.Core.Factory;
using SpeysCloud.Core.Result;
using TemtCash.Main.Api.Services.Validator;
using TemtCash.Main.Domain.Model;
using TemtCash.Main.Domain.Repository;
using TemtCash.Main.Domain.Services;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Request;
using TemtCash.Main.Domain.ViewModel.Services.ProductCatalog.Response;

namespace TemtCash.Main.Api.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IProductCatalogRepository _repository;

        public ProductCatalogService(IProductCatalogRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<PaginatedListResult<ProductsResponseViewModel>>> Search(ProductsRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.Search(viewModel);

            // Mapping
            List<ProductsResponseViewModel> Mapping(List<Product> list)
            {
                return list?
                    .Select(model => new ProductsResponseViewModel
                    {
                        Id = model.Id,
                        ProductName = model.Name,
                        Code = model.Code,
                        EanCode = model.EanCode,
                        SellPriceBruto = model.Price,
                        Type = model.ProductType,
                        ProductGroup = model.ProductCategory?.Name
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<PaginatedListResult<ProductGroupsResponseViewModel>>> SearchListOfProductGroups(ProductGroupsRequestViewModel viewModel)
        {
            var paginatedListWithModel = await _repository.SearchProductCategories(viewModel);

            // Mapping
            List<ProductGroupsResponseViewModel> Mapping(List<ProductCategory> list)
            {
                return list?
                    .Select(model => new ProductGroupsResponseViewModel
                    {
                        Id = model.Id,
                        Name = model.Name,
                        //KmPercent = model.
                    })
                    .ToList();
            }

            var paginatedListWithViewModel = paginatedListWithModel.Copy(Mapping);
            return ServiceResultFactory.Success(paginatedListWithViewModel);
        }

        public async Task<ServiceResult<ProductRequestViewModel>> GetSingle(int id)
        {
            var model = await _repository.GetSingleAsync(id);
            if (model == null)
            {
                return ServiceResultFactory.Success<ProductRequestViewModel>(null);
            }

            var viewModel = new ProductRequestViewModel
            {
                ProductName = model.Name,
                Code = model.Code,
                EanCode = model.EanCode,
                ProductGroupId = model.ProductCategoryId,
                Description = model.Description,
                SellingPriceBruto = model.Price,
                VatPercent = model.Vat,
                Type = model.ProductType,
                Unit = model.Unit,
                UseProductVat = model.UseProductVat
            };

            return ServiceResultFactory.Success(viewModel);
        }

        public async Task<ServiceResult<int>> Create(ProductCreateOrUpdateRequestViewModel viewModel)
        {
            var model = new Product();
            MapViewModelToModel(viewModel, model);

            var validator = new ProductCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return ServiceResultFactory.Fail<int>(validationResult);
            }

            await _repository.AddAsync(model);
            var changes = await _repository.SaveChangesAsync();
            if (changes == 0)
                return ServiceResultFactory.Fail<int>("Insert fails");
            return ServiceResultFactory.Success(model.Id);
        }

        public async Task<ServiceResult<bool>> Update(int id, ProductCreateOrUpdateRequestViewModel viewModel)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(id));

            var model = await _repository.GetSingleAsync(id);
            MapViewModelToModel(viewModel, model);

            var validator = new ProductCreateOrUpdateRequestViewModelValidator();
            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                return ServiceResultFactory.Fail<bool>(validationResult);
            }

            _repository.Update(model);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        public async Task<ServiceResult<bool>> Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Argument should be greater than 0", nameof(id));

            var model = await _repository.GetSingleAsync(id);
            _repository.Delete(model);
            var changes = await _repository.SaveChangesAsync();
            return ServiceResultFactory.Success(changes > 0);
        }

        private void MapViewModelToModel(ProductCreateOrUpdateRequestViewModel viewModel, Product model)
        {
            model.Name = viewModel.ProductName;
            model.Code = viewModel.Code;
            model.EanCode = viewModel.EanCode;
            model.ProductCategoryId = viewModel.ProductGroupId;
            model.Description = viewModel.Description;
            model.Price = viewModel.SellingPriceBruto;
            model.Vat = viewModel.VatPercent;
            model.ProductType = viewModel.Type;
            model.Unit = viewModel.Unit;
            model.UseProductVat = viewModel.UseProductVat;
        }
    }
}