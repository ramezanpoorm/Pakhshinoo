
using _01_PakhshinoQuery.Contract.Brand;
using ShopManagement.InfraStructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_PakhshinoQuery.Query
{
    public class BrandQuery : IBrandQuery
    {
        private readonly ShopContext _shopContext;
        public BrandQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<BrandQueryModel> GetBrand()
        {
            return _shopContext.Brands.Select(x => new BrandQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                Url = x.Url
            }).ToList();
        }
    }
}
