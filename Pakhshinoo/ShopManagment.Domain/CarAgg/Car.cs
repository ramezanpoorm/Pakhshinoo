
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
        public bool IsRemoved { get; set; }
        public Car()
        {
            //Products = new List<Product>();
        }

        public Car(string name, string description)
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
