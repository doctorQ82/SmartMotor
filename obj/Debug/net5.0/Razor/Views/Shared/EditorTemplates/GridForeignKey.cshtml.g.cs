#pragma checksum "D:\FCI\SmartMotor\Views\Shared\EditorTemplates\GridForeignKey.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e557156996bc43f700f5accc5ec8a953cb50540"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_GridForeignKey), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/GridForeignKey.cshtml")]
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
#line 1 "D:\FCI\SmartMotor\Views\_ViewImports.cshtml"
using SmartMotor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FCI\SmartMotor\Views\_ViewImports.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e557156996bc43f700f5accc5ec8a953cb50540", @"/Views/Shared/EditorTemplates/GridForeignKey.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ca574c0602a6c6e24c17df23a182afc2df1b9ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_GridForeignKey : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<object>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("           \r\n");
#nullable restore
#line 3 "D:\FCI\SmartMotor\Views\Shared\EditorTemplates\GridForeignKey.cshtml"
Write(
 Html.Kendo().DropDownListFor(m => m)        
        .BindTo((SelectList)ViewData[ViewData.TemplateInfo.GetFullHtmlFieldName("") + "_Data"])
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<object> Html { get; private set; }
    }
}
#pragma warning restore 1591