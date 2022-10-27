
using ShopManagement.Application.Contracts.Order;
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.Oredr
{
    public interface IOrderQuery
    {
        OrderViewModel GetOrderByIssudTrakingNo(string IssueTrackingNo);
        List<OrderItemViewModel> GetOrderItem(long orderId);
    }
}
