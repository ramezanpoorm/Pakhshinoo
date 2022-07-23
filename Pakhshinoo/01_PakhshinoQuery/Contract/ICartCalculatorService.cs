
using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract
{
    public interface ICartCalculatorService
    {
        Cart ComputeCart(List<CartItem> cartItems);
    }
}
