
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Domain.OrderAgg;
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetDetails(long id);
        List<ProductQueryModel> GetSpecialProducts();
        List<ProductQueryModel> GetAllSpecialProducts(int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId);
        List<ProductQueryModel> GetLatestProducts();
        List<ProductQueryModel> GetAllProducts(int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId);
        List<CartItem> CheckInventoryStatus(List<CartItem> cartItems);
        List<OrderItemViewModel> GetOrderItemsIndex();
        List<OrderItemViewModel> GetOrderItems();
        List<ProductQueryModel> GetMostVisitProducts(int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId);
        List<ProductQueryModel> GetMostVisitProductsIndex();
        List<ProductQueryModel> Search(string value, int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId);
    }
}
