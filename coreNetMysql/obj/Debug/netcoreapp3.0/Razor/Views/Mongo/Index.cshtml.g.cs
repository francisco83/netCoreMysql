#pragma checksum "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/Mongo/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64d04dd6e4146ec1d57556e0312dc4393c0162ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Mongo_Index), @"mvc.1.0.view", @"/Views/Mongo/Index.cshtml")]
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
#line 1 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/_ViewImports.cshtml"
using coreNetMysql;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/_ViewImports.cshtml"
using coreNetMysql.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64d04dd6e4146ec1d57556e0312dc4393c0162ad", @"/Views/Mongo/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"518b00bbed6838628259d2dcf380b70ea39b7f01", @"/Views/_ViewImports.cshtml")]
    public class Views_Mongo_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<coreNetMysql.Models.DatosSensores>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<table border=\"1\">\n    <tr>\n        <th>Fecha</th>\n        <th>Temperatura</th>\n        <th>Humedad</th>\n        <th>Luminosidad</th>\n        <th>Volts Panel</th>\n        <th>Volts Bateria</th>\n    </tr>\n\n");
#nullable restore
#line 18 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/Mongo/Index.cshtml"
     foreach(var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n            <td>");
#nullable restore
#line 21 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/Mongo/Index.cshtml"
           Write(item.Fecha);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 22 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/Mongo/Index.cshtml"
           Write(item.Temperatura);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 23 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/Mongo/Index.cshtml"
           Write(item.Humedad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 24 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/Mongo/Index.cshtml"
           Write(item.Luminosidad);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 25 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/Mongo/Index.cshtml"
           Write(item.Voltspanel);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 26 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/Mongo/Index.cshtml"
           Write(item.Voltsbateria);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n");
#nullable restore
#line 28 "/Users/fran/Projects/netCoreMysql/coreNetMysql/Views/Mongo/Index.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<coreNetMysql.Models.DatosSensores>> Html { get; private set; }
    }
}
#pragma warning restore 1591
