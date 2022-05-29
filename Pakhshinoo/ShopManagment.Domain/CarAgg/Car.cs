
using _0_Framework.Domain;
using ShopManagement.Domain.CarProductAgg;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.CarAgg
{
    public class Car : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public List<CarProduct> CarProducts { get; private set; }

        public Car()
        {
            //Products = new List<Product>();
        }

        public Car(string name, string description)
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
