#pragma checksum "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\Home\Coberturas.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69103312699561782bbd5ac9986189b51f772456"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Coberturas), @"mvc.1.0.view", @"/Views/Home/Coberturas.cshtml")]
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
#line 1 "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\_ViewImports.cshtml"
using unq_iisoft_2021_c1_hospitalWebSite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\_ViewImports.cshtml"
using unq_iisoft_2021_c1_hospitalWebSite.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69103312699561782bbd5ac9986189b51f772456", @"/Views/Home/Coberturas.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9bcf455f70641fe5734fdd0cdb3b0e8e46cfd86", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Coberturas : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"title-page\">\r\n  Coberturas\r\n</div>\r\n\r\n<div class=\"container\">\r\n  <div class=\"row row-cols-4\">\r\n\r\n");
#nullable restore
#line 8 "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\Home\Coberturas.cshtml"
     foreach (var os in ViewBag.ObrasSociales)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("      <div class=\"card text-white bg-dark mb-3\" id=\"card-os\">\r\n        <div class=\"card-header\">\r\n            ");
#nullable restore
#line 13 "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\Home\Coberturas.cshtml"
       Write(os.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <a");
            BeginWriteAttribute("href", " href=", 289, "", 308, 1);
#nullable restore
#line 13 "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\Home\Coberturas.cshtml"
WriteAttributeValue("", 295, os.PaginaWeb, 295, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\">\r\n            <i class=\"fas fa-globe\" style=\"color: white;\"></i></a>\r\n        </div>\r\n        <div class=\"card-body\">\r\n          <h5 class=\"card-title\">Planes</h5>\r\n          <p class=\"card-text\">\r\n");
#nullable restore
#line 19 "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\Home\Coberturas.cshtml"
             foreach (var plan in @os.Planes){

#line default
#line hidden
#nullable disable
            WriteLiteral("              <div style=\"font-family: \'Quicksand\', sans-serif;\">??? ");
#nullable restore
#line 20 "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\Home\Coberturas.cshtml"
                                                              Write(plan.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
#nullable restore
#line 21 "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\Home\Coberturas.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("          </p>\r\n        </div>\r\n      </div>\r\n");
#nullable restore
#line 25 "C:\Users\MarianoX\Documents\Isoft\unq-iisoft-2021-c1-hospitalWebSite\unq-iisoft-2021-c1-hospitalWebSite\Views\Home\Coberturas.cshtml"
 }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n  </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
