#pragma checksum "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ccae36673020e41b0f21e13446f5c90f4cfce69d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cart/Index.cshtml", typeof(AspNetCore.Views_Cart_Index))]
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
#line 1 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\_ViewImports.cshtml"
using SportsStore1.Models;

#line default
#line hidden
#line 2 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\_ViewImports.cshtml"
using SportsStore1.Models.ViewModels;

#line default
#line hidden
#line 3 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\_ViewImports.cshtml"
using SportsStore1.Infrastructure;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ccae36673020e41b0f21e13446f5c90f4cfce69d", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69fc9c0ebec226d9b447033df75180eaaba4fd6f", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CartIndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(27, 308, true);
            WriteLiteral(@"
<h2>Twój koszyk</h2>
<table class=""table table-bordered table-striped"">
    <thead>
        <tr>
            <th>Ilość</th>
             <th>Produkt</th>
            <th class=""text-right"">Cena</th>
            <th class=""text-right"">Wartość</th>
            </tr>>
        </thead>
    <tbody>
");
            EndContext();
#line 14 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\Cart\Index.cshtml"
         foreach(var line in Model.Cart.lines)
        {

#line default
#line hidden
            BeginContext(394, 50, true);
            WriteLiteral("        <tr>\r\n            <td class=\"text-center\">");
            EndContext();
            BeginContext(445, 12, false);
#line 17 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\Cart\Index.cshtml"
                               Write(line.Quanity);

#line default
#line hidden
            EndContext();
            BeginContext(457, 41, true);
            WriteLiteral("</td>\r\n            <td class=\"text-left\">");
            EndContext();
            BeginContext(499, 17, false);
#line 18 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\Cart\Index.cshtml"
                             Write(line.Product.Name);

#line default
#line hidden
            EndContext();
            BeginContext(516, 42, true);
            WriteLiteral("</td>\r\n            <td class=\"text-right\">");
            EndContext();
            BeginContext(559, 32, false);
#line 19 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\Cart\Index.cshtml"
                              Write(line.Product.Price.ToString("c"));

#line default
#line hidden
            EndContext();
            BeginContext(591, 42, true);
            WriteLiteral("</td>\r\n            <td class=\"text-right\">");
            EndContext();
            BeginContext(635, 47, false);
#line 20 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\Cart\Index.cshtml"
                               Write((line.Quanity*line.Product.Price).ToString("c"));

#line default
#line hidden
            EndContext();
            BeginContext(683, 24, true);
            WriteLiteral("</td>\r\n\r\n        </tr>\r\n");
            EndContext();
#line 23 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\Cart\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(718, 135, true);
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <td colspan=\"3\"class=\"text-right\">Razem:</td>\r\n            <td class=\"text-right\">");
            EndContext();
            BeginContext(854, 44, false);
#line 28 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\Cart\Index.cshtml"
                              Write(Model.Cart.ComputeTotalValue().ToString("c"));

#line default
#line hidden
            EndContext();
            BeginContext(898, 107, true);
            WriteLiteral("</td>\r\n        </tr>\r\n    </tfoot>\r\n    </table>\r\n<div class=\"text-center\">\r\n    <a class=\"btn btn-primary\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1005, "\"", 1028, 1);
#line 33 "C:\Users\Góri\source\repos\SportsStore1\SportsStore1\Views\Cart\Index.cshtml"
WriteAttributeValue("", 1012, Model.ReturnUrl, 1012, 16, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1029, 31, true);
            WriteLiteral(">Kontynuuj zakupy</a>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CartIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591