#pragma checksum "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "36ba55089d07334a6a0fa7102707e641d22b189a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Administration.Pages.Inventory.Areas_Administrator_Pages_Inventory_OperationLog), @"mvc.1.0.view", @"/Areas/Administrator/Pages/Inventory/OperationLog.cshtml")]
namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36ba55089d07334a6a0fa7102707e641d22b189a", @"/Areas/Administrator/Pages/Inventory/OperationLog.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5e25ad8efa72e2da71cf3335257970b7e2689da", @"/Areas/Administrator/Pages/_ViewImports.cshtml")]
    public class Areas_Administrator_Pages_Inventory_OperationLog : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal-header"">
    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
    <h4 class=""modal-title"">سوابق گردش انبار</h4>
</div>

    <div class=""modal-body"">
        <table class=""table table-bordered""> 
            <thead>
                <tr>
                    <th>#</th>
                    <th>تعداد</th>
                    <th>تاریخ سابقه</th>
                    <th>عملیات</th>
                    <th>نام کاربر</th>
                    <th>توضیحات</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 23 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("class", " class=\"", 778, "\"", 843, 2);
            WriteAttributeValue("", 786, "text-white", 786, 10, true);
#nullable restore
#line 25 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
WriteAttributeValue(" ", 796, item.Operation ? "bg-success" : "bg-danger", 797, 46, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>");
#nullable restore
#line 26 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 27 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                   Write(item.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 28 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                   Write(item.OperationDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>\r\n");
#nullable restore
#line 30 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                         if (item.Operation)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>افزایش</span>");
#nullable restore
#line 31 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                                             }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span>کاهش</span>");
#nullable restore
#line 33 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>");
#nullable restore
#line 35 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                   Write(item.CurrentCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 36 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                   Write(item.Operator);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                   Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 39 "D:\PakhshinooCore\code\Pakhshinoo\ServiceHost\Areas\Administrator\Pages\Inventory\OperationLog.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"modal-footer\">\r\n        <button type=\"button\" class=\"btn btn-default waves-effect\" data-dismiss=\"modal\">بستن</button>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<InventoryManagement.Application.Contract.Inventory.InventoryOperationViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
