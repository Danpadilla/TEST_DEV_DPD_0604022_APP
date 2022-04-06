#pragma checksum "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f8d6445386fe4c37205822d18a96b4f7a38b9154"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reportes_Index), @"mvc.1.0.view", @"/Views/Reportes/Index.cshtml")]
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
#line 1 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\_ViewImports.cshtml"
using TokaWeb.APP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\_ViewImports.cshtml"
using TokaWeb.APP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8d6445386fe4c37205822d18a96b4f7a38b9154", @"/Views/Reportes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa1e76c3c96002e79529358b5f38438f5409b131", @"/Views/_ViewImports.cshtml")]
    public class Views_Reportes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
  
    var clientes = ViewBag.Clientes;  

#line default
#line hidden
#nullable disable
            WriteLiteral(@" <div class=""row"">
     <div class=""col-md-12"">
         <table id=""tablaclientes"" class=""display"" style=""width:100%"">
        <thead>
            <tr>
                <th>Cliente</th>
                <th>RazonSocial</th>
                <th>RFC</th>
                <th>FechaRegistroEmpresa</th>
                <th>Sucursal</th>
                <th>Nombre</th>
                <th>IdViaje</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 22 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                 foreach (var row in clientes)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 25 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                       Write(row.IdCliente);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 26 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                       Write(row.RazonSocial);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 27 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                       Write(row.RFC);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 28 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                       Write(row.FechaRegistroEmpresa);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 29 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                       Write(row.Sucursal);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 30 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                       Write(row.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                                   Write(row.Paterno);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 30 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                                                Write(row.Materno);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"
                       Write(row.IdViaje);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>         \r\n");
#nullable restore
#line 33 "C:\Users\danpd\source\repos\TokaWeb.APP\TokaWeb.APP\Views\Reportes\Index.cshtml"

                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"           
        </tbody>
        <tfoot>
            <tr>
                <th>Cliente</th>
                <th>RazonSocial</th>
                <th>RFC</th>
                <th>FechaRegistroEmpresa</th>
                <th>Sucursal</th>
                <th>Nombre</th>
                <th>IdViaje</th>
            </tr>
        </tfoot>
    </table>
     </div>
 </div>
");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js""></script> 
 <script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.2/js/dataTables.buttons.min.js""></script> 
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></script> 
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/pdfmake.min.js""></script> 
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script> 
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.2/js/buttons.html5.min.js""></script> 
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.2/js/buttons.print.min.js""></script> 
    <script>
        $(document).ready(function() {
                $('#tablaclientes').DataTable({
                    ""pageLength"": 20,
                    dom: 'Bfrtip',
                    buttons: [ 
 ");
                WriteLiteral("                       \'excel\' \r\n                    ]\r\n                });\r\n        } );\r\n    </script>\r\n");
            }
            );
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
