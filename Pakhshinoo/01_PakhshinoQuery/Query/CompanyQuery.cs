﻿using _01_PakhshinoQuery.Contract.Brand;
using _01_PakhshinoQuery.Contract.Company;
using ShopManagement.InfraStructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_PakhshinoQuery.Query
{
    public class CompanyQuery : ICompanyQuery
    {
        private readonly ShopContext _shopContext;
        public CompanyQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<CompanyQueryModel> GetCompany()
        {
            return _shopContext.Companies.Where(x => x.IsRemoved == false).Select(x => new CompanyQueryModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
