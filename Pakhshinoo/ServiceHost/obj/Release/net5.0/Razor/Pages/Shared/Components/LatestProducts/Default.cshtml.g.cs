#pragma checksum "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb35f0d83fb53aae6ace8e1908822a2ccd73bc02"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Shared.Components.LatestProducts.Pages_Shared_Components_LatestProducts_Default), @"mvc.1.0.view", @"/Pages/Shared/Components/LatestProducts/Default.cshtml")]
namespace ServiceHost.Pages.Shared.Components.LatestProducts
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb35f0d83fb53aae6ace8e1908822a2ccd73bc02", @"/Pages/Shared/Components/LatestProducts/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Shared_Components_LatestProducts_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<_01_PakhshinoQuery.Contract.Product.ProductQueryModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("نمایش محصول"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-toggle", new global::Microsoft.AspNetCore.Html.HtmlString("tooltip"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("quickview-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("75"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("75"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("attachment-simplev size-simplev wp-post-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
    <section class=""elementor-section elementor-top-section elementor-element elementor-section-boxed elementor-section-height-default elementor-section-height-default"">
        <div class=""elementor-container elementor-column-gap-narrow"">
            <div class=""elementor-row"">
                <div class=""elementor-column elementor-col-100 elementor-top-column elementor-element"">
                    <div class=""elementor-column-wrap elementor-element-populated"">
                        <div class=""elementor-widget-wrap"">
                            <div class=""elementor-element row-is-d-noflex-1 elementor-widget elementor-widget-small-list-product"">
                                <div class=""elementor-widget-container"">
                                    <div class=""mweb-block-wrap"">
                                        <div class=""block-title has_url"">
                                            <div class=""title""><i class=""fal fa-layer-plus""></i>جدیدترین محصـولات</div>
                   ");
            WriteLiteral(@"                         <a href=""#"" class=""bk_view_more"" title=""جدیدترین محصـولات""><i class=""fal fa-angle-left""></i>مشاهده همه</a>
                                        </div>

                                        
		 
	
                                        <div class=""block-content-wrap"">
                                            <div class=""block-content-inner clear row"">
");
#nullable restore
#line 22 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                 foreach (var product in Model)
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                    <div class=""item item_simple col-12 col-sm-6 col-lg-4"">
                                                        <div class=""item-area clear"">
                                                            <div class=""product-image-area"">
                                                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb35f0d83fb53aae6ace8e1908822a2ccd73bc028256", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 27 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                                                                                                          WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                                <div class=\"is-image product-image\">\r\n                                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb35f0d83fb53aae6ace8e1908822a2ccd73bc0210923", async() => {
                WriteLiteral("\r\n                                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "eb35f0d83fb53aae6ace8e1908822a2ccd73bc0211251", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                AddHtmlAttributeValue("", 2452, "~/ProductPictures/", 2452, 18, true);
#nullable restore
#line 30 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
AddHtmlAttributeValue("", 2470, product.Picture, 2470, 16, false);

#line default
#line hidden
#nullable disable
                EndAddHtmlAttributeValues(__tagHelperExecutionContext);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                                             WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 29 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
AddHtmlAttributeValue("", 2322, product.PictureTitle, 2322, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
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
                                                            <div class=""product-detail-area"">
                                                                <h2 class=""product-name"">
                                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eb35f0d83fb53aae6ace8e1908822a2ccd73bc0216100", async() => {
#nullable restore
#line 36 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                                                                                       Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 36 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                                             WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "title", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 36 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
AddHtmlAttributeValue("", 3078, product.Name, 3078, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                                                </h2>\r\n                                                                <div class=\"row\">\r\n                                                                    <span class=\"price\">\r\n");
#nullable restore
#line 40 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                         if (product.HasDiscount)
                                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                            <del aria-hidden=\"true\"><span class=\"Price-amount amount\"><bdi>");
#nullable restore
#line 42 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                                                                                      Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;<span>تومان</span></bdi></span></del>\r\n");
            WriteLiteral("                                                                            <ins><span class=\"Price-amount amount\"><bdi>");
#nullable restore
#line 44 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                                                                   Write(product.PriceWithDiscount);

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;<span>تومان</span></bdi></span></ins>\r\n");
#nullable restore
#line 45 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                        }
                                                                        else
                                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                            <ins><span class=\"Price-amount amount\"><bdi>");
#nullable restore
#line 48 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                                                                   Write(product.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("&nbsp;<span>تومان</span></bdi></span></ins>\r\n");
#nullable restore
#line 49 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                                    </span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
");
#nullable restore
#line 55 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Pages\Shared\Components\LatestProducts\Default.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                </div>
                                        </div>
                                        

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<_01_PakhshinoQuery.Contract.Product.ProductQueryModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
