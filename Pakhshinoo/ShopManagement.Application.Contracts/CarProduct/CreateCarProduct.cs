
using ShopManagement.Application.Contracts.Car;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.CarProduct
{
    public class CreateCarProduct
    {
        public long CarId { get; set; }
        public long ProductId { get; set; }
        public List<ProductViewModel> Product { get; set; }
        public List<CarViewModel> Car { get; set; }
    }
}
