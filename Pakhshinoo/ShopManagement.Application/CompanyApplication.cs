
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Domain.CompanyAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyApplication(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public OpretaionResult Create(CreateCompany command)
        {
            var operation = new OpretaionResult();
            if (_companyRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var brand = new Company(command.Name, command.Description);
            _companyRepository.Create(brand);
            _companyRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditCompany command)
        {
            var operation = new OpretaionResult();
            var car = _companyRepository.Get(command.Id);

            if (car == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_companyRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            car.Edit(command.Name, command.Description);

            _companyRepository.SaveChanges();
            return operation.Successeded();
        }

        public List<CompanyViewModel> GetCompany()
        {
            return _companyRepository.GetCompanies();
        }

        public EditCompany GetDetails(long id)
        {
            return _companyRepository.GetDetails(id);
        }

        public List<CompanyViewModel> Search(CompanySearchModel searchModel)
        {
            return _companyRepository.Search(searchModel);
        }
    }
}
