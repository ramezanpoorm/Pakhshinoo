#pragma checksum "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59aba4ae8e570c2f4c547feb408dd2302195d9f7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_Cart), @"mvc.1.0.razor-page", @"/Pages/Cart.cshtml")]
namespace ServiceHost.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
using _0_Framework.Application;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59aba4ae8e570c2f4c547feb408dd2302195d9f7", @"/Pages/Cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Cart : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "RemoveFromCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("remove"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("attachment-products_thumbnail size-products_thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "\\Cart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "GoToCheckOut", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("checkout-button button alt wc-forward"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
  
    ViewData["Title"] = "سبد خرید";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
   double total = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""main-site-wrap"">
    <div class=""mweb-site-mask""></div>
    <div class=""site-wrap-outer clear"">
        <div class=""container-wrap page-shopping-cart"">
            <div class=""container"">
                <div class=""order-steps"">
                    <div class=""checkout-breadcrumb"">
                        <div class=""title-cart"">
                            <i class=""fal fa-bags-shopping""></i><a href=""#""><h4>سبد خرید</h4></a>
                        </div>
                        <div class=""title-checkout"">
                            <i class=""fal fa-file-invoice""></i><a href=""#""><h4>جزئیات پرداخت</h4></a>
                        </div>
                        <div class=""title-thankyou"">
                            <i class=""fal fa-receipt""></i><h4>تکمیل سفارش</h4>
                        </div>
                    </div>
                </div>
            </div>

            <div class=""container"">
                <div id=""content"" class=""wc_page_body "">
                ");
            WriteLiteral("    <div class=\"products\">\r\n");
#nullable restore
#line 31 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                         foreach (var items in Model.CartItemsForInventory.Where(x => !x.IsInStock))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"products-notices-wrapper\">\r\n                                <div class=\"products-message\" role=\"alert\">\r\n                                    کالای ");
#nullable restore
#line 35 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                                     Write(items.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" در انبار کمتر از تعداد درخواستی موجود است!\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 38 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""row"">
                                <div class=""col-12 col-sm-12 col-lg-9 products-cart-form clear"">


                                    <table class=""shop_table shop_table_responsive cart products-cart-form__contents"" cellspacing=""0"">
                                        <thead>
                                            <tr>
                                                <th class=""product-remove"">&nbsp;</th>
                                                <th class=""product-thumbnail"">&nbsp;</th>
                                                <th class=""product-name"">محصول</th>
                                                <th class=""product-price"">قیمت واحد</th>
                                                <th class=""product-quantity"">تعداد</th>
                                                <th class=""product-subtotal"">جمع جزء</th>
                                            </tr>
                                        </thead>

   ");
            WriteLiteral("                                     <tbody>\r\n");
#nullable restore
#line 56 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                                             foreach (var item in Model.CartItems)
                                            {


#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr class=\"products-cart-form__cart-item cart_item\">\r\n                                                    <td class=\"product-remove\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59aba4ae8e570c2f4c547feb408dd2302195d9f710059", async() => {
                WriteLiteral("×");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 60 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                                                                                                                      WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                                    <td class=\"product-thumbnail\">\r\n                                                        <a href=\"#\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "59aba4ae8e570c2f4c547feb408dd2302195d9f712518", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3305, "~/ProductPictures/", 3305, 18, true);
#nullable restore
#line 62 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
AddHtmlAttributeValue("", 3323, item.Picture, 3323, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\r\n                                                    </td>\r\n\r\n                                                    <td class=\"product-name\">\r\n                                                        <a href=\"#\">");
#nullable restore
#line 66 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</a>
                                                        <span class=""lead_time el_ready el_lt_cart""><i class=""fal fa-truck-loading""></i> آماده ارسال</span>
                                                        <div class=""clear""></div>
                                                    </td>

                                                    <td class=""product-price"">
                                                        <span class=""products-Price-amount amount""><bdi>");
#nullable restore
#line 72 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                                                                                                   Write(item.UnitPrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"&nbsp;<span class=""products-Price-currencySymbol"">تومان</span></bdi></span>
                                                    </td>

                                                    <td class=""product-quantity"" data-title=""تعداد"">
                                                        <div class=""quantity"">
                                                            <label class=""screen-reader-text"">");
#nullable restore
#line 77 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                                                                                         Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                                                            <input type=\"number\" class=\"input-text qty text\" step=\"1\" min=\"0\"");
            BeginWriteAttribute("max", " max=\"", 4706, "\"", 4712, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 4713, "\"", 4732, 1);
#nullable restore
#line 78 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 4721, item.Count, 4721, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" title=\"تعداد\" size=\"4\"");
            BeginWriteAttribute("placeholder", " placeholder=\"", 4756, "\"", 4770, 0);
            EndWriteAttribute();
            WriteLiteral(" inputmode=\"numeric\"");
            BeginWriteAttribute("onchange", " onchange=\"", 4791, "\"", 4872, 7);
            WriteAttributeValue("", 4802, "changeCartItemCount(\'", 4802, 21, true);
#nullable restore
#line 78 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 4823, item.Id, 4823, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4831, "\',", 4831, 2, true);
            WriteAttributeValue(" ", 4833, "\'totalItemPrice-", 4834, 17, true);
#nullable restore
#line 78 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 4850, item.Id, 4850, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4858, "\',", 4858, 2, true);
            WriteAttributeValue(" ", 4860, "this.value)", 4861, 12, true);
            EndWriteAttribute();
            WriteLiteral(@">
                                                            <div class=""plus-minus"">
                                                                <div class=""increase elm_qty fal fa-plus""></div>
                                                                <div class=""reduced elm_qty fal fa-minus""></div>
                                                            </div>
                                                        </div>
                                                    </td>

                                                    <td class=""product-subtotal"">
                                                        <span class=""products-Price-amount amount""");
            BeginWriteAttribute("id", " id=\"", 5564, "\"", 5592, 2);
            WriteAttributeValue("", 5569, "totalItemPrice-", 5569, 15, true);
#nullable restore
#line 87 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
WriteAttributeValue("", 5584, item.Id, 5584, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><bdi>");
#nullable restore
#line 87 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                                                                                                                                Write(item.TotalItemPrice.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;<span class=\"products-Price-currencySymbol\">تومان</span></bdi></span>\r\n                                                    </td>\r\n\r\n                                                </tr>\r\n");
#nullable restore
#line 91 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"

                                                //total = (item.TotalItemPrice * item.Count) + total;
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                            <tr>\r\n                                                <td colspan=\"6\" class=\"actionss\">\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59aba4ae8e570c2f4c547feb408dd2302195d9f720092", async() => {
                WriteLiteral("بروزرسانی و استعلام انبار");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>


                                </div>

                                <div class=""col-12 col-sm-12 col-lg-3"">
                                    <div class=""cart-collaterals"">
                                        <div class=""col-colla"">
                                            <div class=""cart_totals"">
                                                <h2>جمع کل سبد خرید</h2>
                                                <table class=""shop_table shop_table_responsive"" cellspacing=""0"">
                                                    <tbody>
                                                        <tr class=""cart-subtotal"">
                                                            <th>جمع جزء</th>
                                                            <td><span class=""products-");
            WriteLiteral("Price-amount amount\" id=\"totalJoz\"><bdi>");
#nullable restore
#line 116 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                                                                                                                         Write(Model.Cart.TotalAmount.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"&nbsp;<span class=""products-Price-currencySymbol"">تومان</span></bdi></span></td>
                                                        </tr>
                                                        <tr class=""order-total"">
                                                            <th>مجموع</th>
                                                            <td><strong><span class=""products-Price-amount amount"" id=""totalJozSum""><bdi>");
#nullable restore
#line 120 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Cart.cshtml"
                                                                                                                                    Write(Model.Cart.PayAmount.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"&nbsp;<span class=""products-Price-currencySymbol"">تومان</span></bdi></span></strong> </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <div class=""wc-proceed-to-checkout"">
                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "59aba4ae8e570c2f4c547feb408dd2302195d9f724014", async() => {
                WriteLiteral("\r\n                                                        تکمیل فرایند خرید\r\n                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.PageHandler = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                </div>
            </div>
        </div>
    </div>
</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.CartModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.CartModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.CartModel>)PageContext?.ViewData;
        public ServiceHost.Pages.CartModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
