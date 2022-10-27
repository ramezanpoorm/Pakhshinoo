using _0_Framework.InfraStructure;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Domain.CompanyAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.InfraStructure.EFCore.Repository
{
    public class CompanyRepository : RepositoryBase<long, Company>, ICompanyRepository
    {
        private readonly ShopContext _shopContext;
        public CompanyRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }
        public List<CompanyViewModel> GetCompanies()
        {
            return _shopContext.Companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditCompany GetDetails(long id)
        {
            return _shopContext.Companies.Select(x => new EditCompany()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
            }).FirstOrDefault(x => x.Id == id);
        }

        public string GetNameById(long id)
        {
            return _shopContext.Companies.Select(x => new { x.Id, x.Name }).FirstOrDefault(x => x.Id == id).Name;
        }

        public List<CompanyViewModel> Search(CompanySearchModel searchModel)
        {
            var query = _shopContext.Companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                IsRemoved = x.IsRemoved,
                Name = x.Name
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
