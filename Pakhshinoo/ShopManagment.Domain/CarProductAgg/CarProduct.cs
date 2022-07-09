
using _0_Framework.Domain;
using ShopManagement.Domain.CarAgg;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.CarProductAgg
{
    public class CarProduct : EntityBase
    {
        public long ProductId { get; private set; }
        public long CarId { get; private set; }
        public Product Product { get; private set; }
        public Car Car { get; private set; }
        
        public CarProduct(long productId, long carId)
        {
            ProductId = productId;
            CarId = carId;
        }

        public void Edit(long productId, long carId)
        {
            ProductId = productId;
            CarId = carId;
        }
    }
}
