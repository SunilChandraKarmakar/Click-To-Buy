#pragma checksum "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "72e7418f53a99c40ff739abb35c2e62f758cd29d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Condition_GetProductByCondition), @"mvc.1.0.view", @"/Views/Condition/GetProductByCondition.cshtml")]
namespace AspNetCore
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
#line 1 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\_ViewImports.cshtml"
using ClickToBuy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\_ViewImports.cshtml"
using ClickToBuy.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
using ClickToBuy.Model;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"72e7418f53a99c40ff739abb35c2e62f758cd29d", @"/Views/Condition/GetProductByCondition.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58182b6284b770ec652d8b2f171e7aefd040d64f", @"/Views/_ViewImports.cshtml")]
    public class Views_Condition_GetProductByCondition : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Product>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("90"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Update", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Remove", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
  
    ViewData["Title"] = "Get Product By Condition";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h2 id=""hadertitle"">Product Details</h2>
<hr />

<div class=""row"" style=""margin-top: 30px"">
    <div class=""col-md-12"">
        <table id=""myTable"" class=""display table table-bordered table-striped"">
            <thead>
                <tr>
                    <th>Basic Info</th>
                    <th>Activity</th>
                    <th>Price</th>
                    <th>Picture</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 25 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                 foreach (Product item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            Name : ");
#nullable restore
#line 29 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                              Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Category : ");
#nullable restore
#line 30 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                                  Write(item.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Brand : ");
#nullable restore
#line 31 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                               Write(item.Brand.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                        </td>\r\n                        <td>\r\n                            Condition : ");
#nullable restore
#line 34 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                                   Write(item.Condition.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Status : ");
#nullable restore
#line 35 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                                Write(item.CloseType.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Link : ");
#nullable restore
#line 36 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                              Write(item.Link);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Details : ");
#nullable restore
#line 37 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                                 Write(item.ProductDetails);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            Regular Price : ");
#nullable restore
#line 40 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                                       Write(item.RegularPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                            Offer Price : ");
#nullable restore
#line 41 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                                     Write(item.OfferPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                        </td>\r\n                        <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "72e7418f53a99c40ff739abb35c2e62f758cd29d10350", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1561, "~/", 1561, 2, true);
#nullable restore
#line 43 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
AddHtmlAttributeValue("", 1563, item.Picture, 1563, 13, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72e7418f53a99c40ff739abb35c2e62f758cd29d12093", async() => {
                WriteLiteral("<i class=\"far fa-edit\"></i> Update");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 45 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "72e7418f53a99c40ff739abb35c2e62f758cd29d14621", async() => {
                WriteLiteral("<i class=\"far fa-trash-alt\"></i> Remove");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 46 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                                 WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 49 "F:\C# Project\Web Application - CORE\Click-To-Buy\ClickToBuy\ClickToBuy\Views\Condition\GetProductByCondition.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
