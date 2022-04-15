using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Company;
using System.Collections.Generic;

namespace ShopManagement.Domain.CompanyAgg
{
    public interface ICompanyRepository : IRepository<long, Company>
    {
        List<CompanyViewModel> GetCompanies();
        EditCompany GetDetails(long id);
        string GetNameById(long id);
        List<CompanyViewModel> Search(CompanySearchModel searchModel);
    }
}
