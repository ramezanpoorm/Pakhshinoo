using System;
using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _01_PakhshinoQuery.Contract;
using _01_PakhshinoQuery.Contract.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Contracts.Order;

namespace ServiceHost.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem> CartItems;
        public Cart Cart;
        private readonly ICartService _cartService;
        public List<CartItem> CartItemsForInventory;
        public const string CookieName = "cart-items";
        private readonly IProductQuery _productQuery;
        private readonly ICartCalculatorService _cartCalculatorService;

        public CartModel(ICartCalculatorService cartCalculatorService, ICartService cartService, IProductQuery productQuery)
        {
            Cart = new Cart();
            _cartService = cartService;
            CartItemsForInventory = new List<CartItem>();
            _cartCalculatorService = cartCalculatorService;
            _productQuery = productQuery;
        }

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            CartItems = cartItems;
            foreach (var item in cartItems)
                item.CalculateTotalItemPrice();

            Cart = _cartCalculatorService.ComputeCart(cartItems);
            _cartService.Set(Cart);
            CartItemsForInventory = _productQuery.CheckInventoryStatus(cartItems);
        }

        public IActionResult OnGetRemoveFromCart(long id)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            Response.Cookies.Delete(CookieName);
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            var itemToRemove = cartItems.FirstOrDefault(x => x.Id == id);
            cartItems.Remove(itemToRemove);
            var options = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(2) };
            Response.Cookies.Append(CookieName, serializer.Serialize(cartItems), options);
            return RedirectToPage("/Cart");
        }

        public IActionResult OnGetGoToCheckOut()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];
            var cartItems = serializer.Deserialize<List<CartItem>>(value);
            foreach (var item in cartItems)
            {
                item.TotalItemPrice = item.UnitPrice * item.Count;
            }

            //CartItems = _productQuery.CheckInventoryStatus(cartItems);

            //if (CartItems.Any(x => !x.IsInStock))
            //    return RedirectToPage("/Cart");
            //return RedirectToPage("/Checkout");

            return RedirectToPage(CartItemsForInventory.Any(x => !x.IsInStock) ? "/Cart" : "/Checkout");
        }
    }
}