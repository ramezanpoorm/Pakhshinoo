
using _0_Framework.Domain;
using ShopManagement.Domain.CompanyProductAgg;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.CompanyAgg
{
    public class Company : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<CompanyProduct> CompanyProducts { get; private set; }
        public bool IsRemoved { get; set; }
        public Company()
        {
            //Products = new List<Product>();
        }

        public Company(string name, string description)
        {
            Name = name;
            Description = description;
            IsRemoved = false;
        }

        public void Edit(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public void Removed()
        {
            IsRemoved = true;
        }
        public void NotRemoved()
        {
            IsRemoved = false;
        }
    }
}
