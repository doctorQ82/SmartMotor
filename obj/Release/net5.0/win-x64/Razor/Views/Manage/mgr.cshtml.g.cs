#pragma checksum "D:\FCI\SmartMotor\Views\Manage\mgr.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9ebb733e253ed6350d49feb6fb16e7b7a37907b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manage_mgr), @"mvc.1.0.view", @"/Views/Manage/mgr.cshtml")]
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
#line 3 "D:\FCI\SmartMotor\Views\Manage\mgr.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9ebb733e253ed6350d49feb6fb16e7b7a37907b", @"/Views/Manage/mgr.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ca574c0602a6c6e24c17df23a182afc2df1b9ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Manage_mgr : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\FCI\SmartMotor\Views\Manage\mgr.cshtml"
   ViewData["Title"] = "Manage";
    Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12 col-md-12 col-sm-12\">\r\n        <h5 class=\"text-info\">จัดการบัญชีผู้ใช้งาน</h5>\r\n    </div>\r\n</div>\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-lg-6 col-md-6 k-i-margin-to\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f9ebb733e253ed6350d49feb6fb16e7b7a37907b3881", async() => {
                WriteLiteral("\r\n            <table class=\"table-responsive border-0\">\r\n                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 20 "D:\FCI\SmartMotor\Views\Manage\mgr.cshtml"
                    Write(Html.Kendo().TextBox()
                        .Name("AccountName")
                        .Placeholder("LogonName")
                        .Label(label => label
                        .Content("LogonName")
                        )
                        .HtmlAttributes(new { placeholder = "LogonName", required = "required", validationmessage = "Enter {0}" })
                        );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 30 "D:\FCI\SmartMotor\Views\Manage\mgr.cshtml"
                    Write(Html.Kendo().Button()
                        .Name("BtnSearch")
                        .HtmlAttributes(new { type = "submit", @class = "k-primary" })
                        .Content("เพิ่มบัญชีผู้ใช้งาน"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
#nullable restore
#line 16 "D:\FCI\SmartMotor\Views\Manage\mgr.cshtml"
AddHtmlAttributeValue("", 455, Url.Action("Search"), 455, 21, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>


<script>
    function onRequestEnd(e) {
        if (e.type === ""update"") {
            kendo.alert(""ดำเนินการเปลี่ยนแปลงข้อมูลเสร็จเรียบร้อย"");
        } else if (e.type === ""create"") {
            kendo.alert(""ดำเนินการเพิ่มผู้ใช้งานเสร็จเรียบร้อย"");
        } else if (e.type === ""destroy"") {
            kendo.alert(""ดำเนินการลบข้อมูลเสร็จเรียบร้อย"");
        }
    }
</script>

<div class=""form-group"">
    ");
#nullable restore
#line 55 "D:\FCI\SmartMotor\Views\Manage\mgr.cshtml"
Write(Html.Kendo().DataSource<SmartMotor.Models.UserViewModel>()
        .Name("GridDataSource")
        .Ajax( dataSource => {
            dataSource
                .Batch(true)
                .Model(model =>
                {
                    model.Id(p => p.UserId);
                    model.Field(p => p.UserId).Editable(false);
                    model.Field(p => p.LogonName).Editable(false);
                    model.Field(p => p.DisplayName).Editable(false);
                    model.Field(p => p.Created).Editable(false);

                    model.Field(p => p.CreatedBy).Editable(false);
                    model.Field(p => p.Updated).Editable(false);
                    model.Field(p => p.UpdatedBy).Editable(false);
                })
                .Read(read => read.Action("Users_Read", "Manage"))
                .Update(update => update.Action("Users_Update", "Manage"))
                .Destroy(destroy => destroy.Action("Users_Destroy", "Manage"))
                .PageSize(15)
                .Events(e => e.RequestEnd("onRequestEnd"));
        })
        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12 col-md-12 col-sm-12\">\r\n        ");
#nullable restore
#line 85 "D:\FCI\SmartMotor\Views\Manage\mgr.cshtml"
    Write(Html.Kendo().Grid<SmartMotor.Models.UserViewModel>
    ()
    .Name("Grid")
    .Columns(columns =>
    {
        columns.Bound(o => o.UserId).Width(100).Title("ลำดับ").Groupable(false).HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

        columns.Bound(o => o.LogonName).Title("LogonName").HeaderHtmlAttributes(new { style = "text-align: center;" }).Width(120).Filterable(false);

        columns.Bound(o => o.DisplayName).Title("Display Name").HeaderHtmlAttributes(new { style = "text-align: center;" }).Width(180).Filterable(false);

        columns.Bound(o => o.IsActive).Title("IsActive").HeaderHtmlAttributes(new { style = "text-align: center;" }).Width(120).Filterable(false);

        columns.ForeignKey(p => p.Role.RoleID, (System.Collections.IEnumerable)ViewData["roles"], "RoleID", "RoleName")
        .Title("Role").HeaderHtmlAttributes(new { style = "text-align: center;" }).Width(120);

        columns.Bound(o => o.Updated).Title("Updated").Format("{0:dd/MM/yyyy}").HeaderHtmlAttributes(new { style = "text-align: center;" }).Width(140).Filterable(false);

        columns.Bound(o => o.UpdatedBy).Title("Updated By").HeaderHtmlAttributes(new { style = "text-align: center;" }).Width(120).Filterable(false);

        columns.Command(command => { command.Destroy(); }).Width(140).HeaderHtmlAttributes(new { style = "text-align: center;" });
    })
    .ToolBar(toolbar =>
    {
        toolbar.Save();
    })
    .Editable(editable => editable.Mode(GridEditMode.InCell))
    .HtmlAttributes(new { style = "height:430px;" })
    .Pageable(pager => pager
    .Input(true)
    .Numeric(true)
    .Info(true)
    .PreviousNext(true)
    .Refresh(true)
    )
    .Scrollable()
    .HtmlAttributes(new
    {
        style = "width: 100%;font-family: DB-Ozone-X; font-size:14pt;"
    })
    .DataSource("GridDataSource")
    //.Events(events => events.SaveChanges("saveChanges"))
    .Resizable(resize => resize.Columns(true))
    );

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
</div>


<script>
    function onClick() {
        return kendo.antiForgeryTokens();
    }

    function templateRoleCell(data) {
        var template = """";

        if (data.dirtyFields.IsRole) {
            template += ""<span class='k-dirty'></span>""
        }
        template += o.IsRole.RoleName;

        return template;
    }

    function error_handler(e) {
        if (e.errors) {
            var message = ""Errors:\n"";
            $.each(e.errors, function (key, value) {
                if ('errors' in value) {
                    $.each(value.errors, function () {
                        message += this + ""\n"";
                    });
                }
            });
            alert(message);
        }
    }

    function saveChanges(e) {
        if (!confirm(""คุณต้องการบันทึกข้อมูล หรือไม่?"")) {
            e.preventDefault();
        }
    }

    function Remove(e) {
        if (!confirm(""คุณต้องการลบข้อมูล หรือไม่?"")) {
            e.prevent");
            WriteLiteral(@"Default();
        }
    }
</script>


<style>
    .k-readonly {
        color: gray;
    }

    .k-grid .k-grid-search {
        margin-left: auto;
        margin-right: 0;
    }

    .k-dialog .k-window-titlebar .k-dialog-title {
        visibility: hidden;
    }
</style>
");
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