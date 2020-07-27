#pragma checksum "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9d90489caff021d84500bcc158dcccd2e22efcc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Profile_Index), @"mvc.1.0.view", @"/Views/Profile/Index.cshtml")]
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
#line 1 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\_ViewImports.cshtml"
using SkateboardCollector;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\_ViewImports.cshtml"
using SkateboardCollector.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9d90489caff021d84500bcc158dcccd2e22efcc", @"/Views/Profile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df269ea51170183109b1bb4d07957dcb30ef326e", @"/Views/_ViewImports.cshtml")]
    public class Views_Profile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Tuple<SkateboardCollector.Domain.User,List<SkateboardCollector.Domain.Skateboard>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
  
    ViewData["Title"] = "Profile";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div>\r\n        <div class=\"text-left\">\r\n            <h1 class=\"display-4\">Profile</h1>\r\n            <h3>Username: </h3>\r\n            <p>");
#nullable restore
#line 11 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
          Write(Model.Item1.UserNickname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <h3>Email address:</h3>\r\n            <p>");
#nullable restore
#line 13 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
          Write(Model.Item1.UserEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
        </div>
        <p></p>
        <h2 style=""text-align:center"">Your skateboards</h2>
        <div id=""skateboards"" class=""text-center"">
            <table id=""boardTable"" class=""table table-bordered"" border_spacing=""5px"" style=""white-space:pre"">
                <tr>
                    <th>Deck</th>
                    <th>Truck</th>
                    <th>Wheels</th>
                </tr>
");
#nullable restore
#line 24 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
                 foreach (var board in Model.Item2)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 27 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
                       Write(board.SbDeck.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 28 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
                       Write(board.SbTrucks.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 29 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
                       Write(board.SbWheels.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td><input type=\"button\" class=\"btn btn-primary\" value=\"Delete\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1165, "\"", 1278, 3);
            WriteAttributeValue("", 1175, "location.href=\'", 1175, 15, true);
#nullable restore
#line 30 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
WriteAttributeValue("", 1190, Url.Action("RemoveSkateboardSlot", "Profile",new { skateboardId = board.SkateboardId}), 1190, 87, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1277, "\'", 1277, 1, true);
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n                    </tr>\r\n");
#nullable restore
#line 32 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n            <b>Remember: You can\'t have more than 3 skateboard slots!</b>\r\n        </div>\r\n\r\n        <input type=\"button\" class=\"btn btn-primary\" value=\"Add\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1514, "\"", 1583, 3);
            WriteAttributeValue("", 1524, "location.href=\'", 1524, 15, true);
#nullable restore
#line 37 "C:\WebPA\SkateboardCollectorNet\SkateboardCollector\SkateboardCollector\Views\Profile\Index.cshtml"
WriteAttributeValue("", 1539, Url.Action("AddSkateboardSlot", "Profile"), 1539, 43, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1582, "\'", 1582, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n        \r\n\r\n\r\n\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Tuple<SkateboardCollector.Domain.User,List<SkateboardCollector.Domain.Skateboard>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
