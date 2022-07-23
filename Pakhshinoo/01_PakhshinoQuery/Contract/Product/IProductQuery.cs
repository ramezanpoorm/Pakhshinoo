﻿
using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetDetails(long id);
        List<ProductQueryModel> GetSpecialProducts();
        List<ProductQueryModel> GetLatestProducts();
        List<ProductQueryModel> GetAllProducts(int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId);
        List<CartItem> CheckInventoryStatus(List<CartItem> cartItems);
    }
}
