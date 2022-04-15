
using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Company
{
    public interface ICompanyApplication
    {
        OpretaionResult Create(CreateCompany command);
        OpretaionResult Edit(EditCompany command);
        EditCompany GetDetails(long id);
        List<CompanyViewModel> GetCompany();
        List<CompanyViewModel> Search(CompanySearchModel searchModel);
    }
}
