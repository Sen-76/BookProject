#pragma checksum "E:\Học tập\PRN project\BookProject\BookProject\Views\Shared\Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2143aaebdae6aecf423dc6f704c70a9e6e0d7ed1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Header), @"mvc.1.0.view", @"/Views/Shared/Header.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2143aaebdae6aecf423dc6f704c70a9e6e0d7ed1", @"/Views/Shared/Header.cshtml")]
    #nullable restore
    public class Views_Shared_Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/shenhe__genshin_impact__by_cutesexyrobutts_dew4k8l.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""nav_head ${leftActive}"">
    <div class=""left"">
        <a class=""left_control aaa"">
            <ion-icon name=""list""></ion-icon>
        </a>
        <div onclick=""hmm()"" class=""list aaa"">
            <ion-icon name=""list""></ion-icon>
        </div>

        <form action=""Search"" method=""POST"">
            <div class=""search aaa"">
                <ion-icon name=""search""></ion-icon>
            </div>
            <input type=""hidden"" name=""go"" value=""Search"" />
            <input name=""txt"" type=""text"" placeholder=""Enter somethings..."" class=""mysearch"">
        </form>
    </div>
    <div class=""right"">
        <div class=""history aaa"">
            <a href=""History"">
                <ion-icon name=""alarm""></ion-icon>
            </a>
        </div>
        <div class=""notification aaa"">
            <ion-icon name=""notifications""></ion-icon>
        </div>
");
#nullable restore
#line 27 "E:\Học tập\PRN project\BookProject\BookProject\Views\Shared\Header.cshtml"
         if (ViewBag.UserId == 0 || ViewBag.UserId == null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""login aaa"">
                <a href=""/Home/Login"">
                    <ion-icon name=""person""></ion-icon>
                </a>
                <div style=""display: none"" class=""loged aaa"">
                    <div class=""imgBx"">
                    </div>
                    <span class=""username""></span>
                </div>
            </div>
");
#nullable restore
#line 39 "E:\Học tập\PRN project\BookProject\BookProject\Views\Shared\Header.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "E:\Học tập\PRN project\BookProject\BookProject\Views\Shared\Header.cshtml"
         if (ViewBag.UserId != 0 && ViewBag.UserId != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"loged aaa\">\r\n                <div class=\"imgBx\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "2143aaebdae6aecf423dc6f704c70a9e6e0d7ed15147", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <span class=\"username\">");
#nullable restore
#line 46 "E:\Học tập\PRN project\BookProject\BookProject\Views\Shared\Header.cshtml"
                                   Write(ViewBag.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n            </div>\r\n");
#nullable restore
#line 48 "E:\Học tập\PRN project\BookProject\BookProject\Views\Shared\Header.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"setting aaa\">\r\n            <ion-icon name=\"settings\"></ion-icon>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
