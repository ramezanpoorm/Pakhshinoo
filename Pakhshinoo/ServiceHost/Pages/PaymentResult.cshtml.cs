using System;
using System.Collections.Generic;
using _0_Framework.Application.ZarinPal;
using _01_PakhshinoQuery.Contract.Oredr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    public class PaymentResultModel : PageModel
    {
        public PaymentResult Result;
        public OrderViewModel Order;
        private readonly IOrderQuery _orderQuery;
        
        public List<OrderItemViewModel> OrderItems;
        public PaymentResultModel(IOrderQuery orderQuery)
        {
            _orderQuery = orderQuery;
        }
        public void OnGet(PaymentResult result)
        {
            Result = result;
            Order = _orderQuery.GetOrderByIssudTrakingNo(result.IssueTrackingNo);
            OrderItems = _orderQuery.GetOrderItem(Order.Id);
        }
    }
}
