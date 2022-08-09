
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCompany;
using ShopManagement.Domain.CompanyProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCompanyApplicatipon : IProductCompanyApplication
    {
        private readonly ICompanyProductRepository _companyProductRepository;

        public ProductCompanyApplicatipon(ICompanyProductRepository companyProductRepository)
        {
            _companyProductRepository = companyProductRepository;
        }

        public OpretaionResult Create(CreateProductCompany command)
        {
            var operation = new OpretaionResult();
            if (_companyProductRepository.Exists(x => x.ProductId == command.ProductId && x.CompanyId == command.CompanyId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var companyProduct = new CompanyProduct(command.ProductId, command.CompanyId);
            _companyProductRepository.Create(companyProduct);
            _companyProductRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditProductCompany command)
        {
            var operation = new OpretaionResult();
            var companyProduct = _companyProductRepository.Get(command.id);

            if (companyProduct == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_companyProductRepository.Exists(x => x.ProductId == command.ProductId && x.CompanyId == command.CompanyId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            companyProduct.Edit(command.ProductId, command.CompanyId);
            _companyProductRepository.SaveChanges();

            return operation.Successeded();
        }

        public EditProductCompany GetDetails(long id)
        {
            return _companyProductRepository.GetDetails(id);
        }

        public List<ProductCompanyViewModel> Search(ProductCompanySearchModel searchModel)
        {
            return _companyProductRepository.Search(searchModel);
        }
    }
}
