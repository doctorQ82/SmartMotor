#pragma checksum "D:\FCI\SmartMotor\Views\Shared\EditorTemplates\Currency.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d50cb48f1ad3e56ea00da7b95c5ea6c03dddc81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_EditorTemplates_Currency), @"mvc.1.0.view", @"/Views/Shared/EditorTemplates/Currency.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d50cb48f1ad3e56ea00da7b95c5ea6c03dddc81", @"/Views/Shared/EditorTemplates/Currency.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ca574c0602a6c6e24c17df23a182afc2df1b9ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_EditorTemplates_Currency : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<decimal?>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\FCI\SmartMotor\Views\Shared\EditorTemplates\Currency.cshtml"
Write(Html.Kendo().CurrencyTextBoxFor(m => m)      
      .HtmlAttributes(new {style="width:100%"})
      .Min(0)
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<decimal?> Html { get; private set; }
    }
}
#pragma warning restore 1591
