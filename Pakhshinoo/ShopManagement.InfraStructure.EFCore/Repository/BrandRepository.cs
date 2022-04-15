
using _0_Framework.InfraStructure;
using ShopManagement.Application.Contracts.Brand;
using ShopManagement.Domain.BrandAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.InfraStructure.EFCore.Repository
{
    public class BrandRepository : RepositoryBase<long, Brand>, IBrandRepository
    {
        private readonly ShopContext _shopContext;
        public BrandRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }
        public List<BrandViewModel> GetBrands()
        {
            return _shopContext.Brands.Select(x => new BrandViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditBrand GetDetails(long id)
        {
            return _shopContext.Brands.Select(x => new EditBrand()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
            }).FirstOrDefault(x => x.Id == id);
        }

        public string GetNameById(long id)
        {
            return _shopContext.Brands.Select(x => new { x.Id, x.Name }).FirstOrDefault(x => x.Id == id).Name;
        }

        public List<BrandViewModel> Search(BrandSearchModel searchModel)
        {
            var query = _shopContext.Brands.Select(x => new BrandViewModel
            {
                Id = x.Id,
                Name = x.Name
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
