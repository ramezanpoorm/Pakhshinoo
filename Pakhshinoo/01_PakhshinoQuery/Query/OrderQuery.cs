
using _01_PakhshinoQuery.Contract.Oredr;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.InfraStructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_PakhshinoQuery.Query
{
    public class OrderQuery : IOrderQuery
    {
        private readonly ShopContext _shopContext;
        private long OrderId;
        public OrderQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public OrderViewModel GetOrderByIssudTrakingNo(string IssueTrackingNo)
        {
            return _shopContext.Orders.Where(x => x.IssueTrackingNo == IssueTrackingNo).Select(x => new OrderViewModel
            {
                TotalAmount = x.PayAmount,
                Id = x.Id               
            }).FirstOrDefault();
        }

        public List<OrderItemViewModel> GetOrderItem(long orderId)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var order = _shopContext.Orders.FirstOrDefault(x => x.Id == orderId);
            if (order == null)
                return new List<OrderItemViewModel>();

            var items = _shopContext.OrderItems.Where(x=>x.OrderId == orderId).Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).ToList();

            //var items = order.Items.Select(x => new OrderItemViewModel
            //{
            //    Id = x.Id,
            //    Count = x.Count,
            //    DiscountRate = x.DiscountRate,
            //    OrderId = x.OrderId,
            //    ProductId = x.ProductId,
            //    UnitPrice = x.UnitPrice
            //}).ToList();

            foreach (var item in items)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            }

            return items;
        }
    }
}
