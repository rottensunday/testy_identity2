#pragma checksum "D:\Nauka\repos\testy_identity2\testy_identity\Pages\ChatRoom.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9e3d2cdf15b301d9fe630455bf6ed35afb8073a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(testy_identity.Pages.Pages_ChatRoom), @"mvc.1.0.razor-page", @"/Pages/ChatRoom.cshtml")]
namespace testy_identity.Pages
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
#line 1 "D:\Nauka\repos\testy_identity2\testy_identity\Pages\_ViewImports.cshtml"
using testy_identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Nauka\repos\testy_identity2\testy_identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Nauka\repos\testy_identity2\testy_identity\Pages\_ViewImports.cshtml"
using testy_identity.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9e3d2cdf15b301d9fe630455bf6ed35afb8073a", @"/Pages/ChatRoom.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9508dcd79a7da6c34829ba21518a34679b89f73f", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ChatRoom : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\Nauka\repos\testy_identity2\testy_identity\Pages\ChatRoom.cshtml"
  
    ViewData["Title"] = "ChatRoom";
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">
    <div class=""col-2"">Message</div>
    <div class=""col-4""><input type=""text"" id=""messageInput"" /></div>
</div>
<div class=""row justify-content-between"">
    <div class=""col-6"">
        <input type=""button"" id=""sendButton"" value=""Send Message"" />
    </div>
    <div class=""col-4"">
        <h4>Connected users:</h4>
        <ul>
");
#nullable restore
#line 19 "D:\Nauka\repos\testy_identity2\testy_identity\Pages\ChatRoom.cshtml"
             foreach(User user in Model.Users)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>");
#nullable restore
#line 21 "D:\Nauka\repos\testy_identity2\testy_identity\Pages\ChatRoom.cshtml"
               Write(user.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 22 "D:\Nauka\repos\testy_identity2\testy_identity\Pages\ChatRoom.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>\r\n\r\n<ul id=\"messagesList\">\r\n</ul>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<User> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<testy_identity.ChatRoomModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<testy_identity.ChatRoomModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<testy_identity.ChatRoomModel>)PageContext?.ViewData;
        public testy_identity.ChatRoomModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
