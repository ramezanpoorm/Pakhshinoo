
using _0_Framework.Domain;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.CompanyAgg
{
    public class Company : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<Product> Products { get; private set; }

        public Company()
        {
            Products = new List<Product>();
        }

        public Company(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void Edit(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
