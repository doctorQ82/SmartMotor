#pragma checksum "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06eea6e39f3a31ce07270e84dcc25846716dbb5f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Policy_Inq), @"mvc.1.0.view", @"/Views/Policy/Inq.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06eea6e39f3a31ce07270e84dcc25846716dbb5f", @"/Views/Policy/Inq.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ca574c0602a6c6e24c17df23a182afc2df1b9ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Policy_Inq : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral("\r\n<br />\r\n<div class=\"row\">\r\n    <div class=\"col-lg-12 col-md-12 col-sm-12\">\r\n        <h5 class=\"text-info\">Policy Inquiry</h5>\r\n    </div>\r\n</div>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06eea6e39f3a31ce07270e84dcc25846716dbb5f3562", async() => {
                WriteLiteral("\r\n    <div class=\"row\">\r\n\r\n        <div class=\"col-4 col-sm-4 col-md-4\">\r\n\r\n            <div class=\"form-group\">\r\n                ");
#nullable restore
#line 20 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
            Write(Html.Kendo().TextBox()
                        .Name("txtSearch")
                        .Placeholder("ค้นหาทะเบียนรถยนต์ ,กรมธรรม์ และ GpsID")
                          .HtmlAttributes(new { style = "width: 100%", placeholder = "ทะเบียนรถยนต์ หรือกรมธรรม์", required = "required", validationmessage = "Enter {0}" })
                    );

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n\r\n\r\n        </div>\r\n        <div class=\"col-4 col-sm-4 col-md-4\">\r\n            <div class=\"form-group text-left\">\r\n                ");
#nullable restore
#line 31 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
            Write(Html.Kendo().Button()
                        .Name("BtnSearch")
                        .HtmlAttributes(new { type = "submit", @class = "k-primary" })
                        .Content("ค้นหาข้อมูล"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n");
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
#line 14 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
AddHtmlAttributeValue("", 309, Url.Action("Inq"), 309, 18, false);

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
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-4 col-lg-4\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06eea6e39f3a31ce07270e84dcc25846716dbb5f6778", async() => {
                WriteLiteral("\r\n            ");
#nullable restore
#line 44 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
        Write(Html.Kendo().Button()
            .Name("btnClearInq")
            .HtmlAttributes(new { type = "submit" , @class = "k-primary"})
            .Content("ล้างค่า"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("a", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "action", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
#nullable restore
#line 43 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
AddHtmlAttributeValue("", 1319, Url.Action("InqClear"), 1319, 23, false);

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
    <div class=""col-md-8 col-lg-8"">

    </div>
</div>
<br />

<script>
    function onRequestEnd(e) {
        if (e.type === ""update"") {
            kendo.alert(""ดำเนินการเปลี่ยนแปลงข้อมูลเสร็จเรียบร้อย"");
        } else if (e.type === ""create"") {
            kendo.alert(""ดำเนินการเพิ่มข้อมูลเสร็จเรียบร้อย"");
        } else if (e.type === ""destroy"") {
            kendo.alert(""ดำเนินการลบข้อมูลเสร็จเรียบร้อย"");
        }
    }
</script>

<div class=""form-group"">
    ");
#nullable restore
#line 69 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
Write(Html.Kendo().DataSource<SmartMotor.Models.PolicyInquiryViewModel>()
        .Name("GridDataSource")
        .Ajax( dataSource => {
            dataSource
                .Batch(true)
                .Model(model =>
                {
                    model.Id(p => p.rnPolicy);
                    model.Field(p => p.assuredName).Editable(false);
                    model.Field(p => p.policyNo).Editable(false);
                    model.Field(p => p.carRegistrationNo).Editable(false);
                    model.Field(p => p.policyStartDate).Editable(false);
                    model.Field(p => p.policyEndDate).Editable(false);
                    model.Field(p => p.policyBasePremium).Editable(false);
                    model.Field(p => p.policyPremiumPerKm).Editable(false);
                    model.Field(p => p.carModel).Editable(false);
                    model.Field(p => p.PolicyType).Editable(false);
                    model.Field(p => p.PolicyStatus).Editable(false);
                })
                .Read("Inquiry_Read", "Policy")
                .Update("Policy_Update", "Policy")
                .PageSize(15)
                .Events(e => e.RequestEnd("onRequestEnd"));
        })
        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-md-12 col-lg-12\">\r\n        ");
#nullable restore
#line 99 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
    Write(Html.Kendo().Grid<SmartMotor.Models.PolicyInquiryViewModel>()
            .Name("Grid")
            .Columns(columns =>
            {
                columns.Bound(o => o.assuredName).Title("assuredName").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.policyNo).Title("policyNo").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.carRegistrationNo).Title("carRegistrationNo").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.policyStartDate).Title("policyStartDate").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.policyEndDate).Title("policyEndDate").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.policyBasePremium).Title("policy BasePremium").HeaderHtmlAttributes(new { style = "text-align: right;" }).Filterable(false);

                columns.Bound(o => o.policyPremiumPerKm).Title("policy PremiumPerKm").HeaderHtmlAttributes(new { style = "text-align: right;" }).Filterable(false);

                columns.Bound(o => o.gpsId).Title("gpsId").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.carModel).Title("carModel").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.PolicyType).Title("PolicyType").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.PolicyStatus).Title("PolicyStatus").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

            })
             .ToolBar(t =>
             {
                 t.Save();
             }
              )
             .Scrollable()
             .ClientDetailTemplateId("template")
             .Editable(editable => editable.Mode(GridEditMode.InCell))
             .Navigatable()
             .HtmlAttributes(new
             {
                 style = "width: 100%;font-family: DB-Ozone-X; font-size:14pt;"
             })
             .DataSource("GridDataSource")
            .Pageable(pager => pager
                .Info(true)
                .Refresh(true)
            )
            .Resizable(resize => resize.Columns(true))
            .Events(events => events
                .DataBound("dataBound")
            )
        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n\r\n<script id=\"template\" type=\"text/kendo-tmpl\">\r\n    ");
#nullable restore
#line 154 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
Write(Html.Kendo().Grid<SmartMotor.Models.PolicyPaymentDetail>()
            .Name("grid_#=rnPolicy#")
            .Columns(columns =>
            {
                columns.Bound(o => o.start_bill_date).Title("Start Period").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.end_bill_date).Title("End Period").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.period_no).Title("Period No").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.invoice_no).Title("Invoice No").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.payment_due_date).Title("Due Date").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

        columns.Bound(o => o.gps_id).Title("gpsId").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);


                columns.Bound(o => o.payment_type).Title("Payment Type").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.payment_status).Title("Status").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.paid_date).Title("Paid Date").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.total_distance).Title("Distance (KM)").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.premium_per_km).Title("Premium Per KM").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.total_amount_insurer).Title("Amount (THB)").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);
            })
            .DataSource(dataSource => dataSource
                .Ajax()
                .Read(read => read.Action("Inquiry_Detail", "Policy", new { rnPolicy = "#=rnPolicy#" }))
            )
            .HtmlAttributes(new
            {
                style = "width: 100%;font-family: DB-Ozone-X; font-size:14pt;"
            })
            .Sortable()
            .Resizable(resize => resize.Columns(true))
            .ToClientTemplate()
);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</script>\r\n\r\n\r\n");
#nullable restore
#line 198 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
Write(Html.Kendo().ContextMenu()
    .Name("contextmenu")
    .Target("#Grid")
    .Filter("tr[role = 'row']")
    .Events(ev => { ev.Select("onSelect"); })
    .Orientation(ContextMenuOrientation.Vertical)
    .Animation(animation =>
    {
        animation.Open(open =>
        {
            open.Fade(FadeDirection.In);
            open.Duration(500);
        });
    })
    .Items(items =>
    {
        items.Add().Text("Inactive").HtmlAttributes(new { id = "Inactive" });
    })
);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<style>
    .k-grid .k-grid-search {
        margin-left: auto;
        margin-right: 0;
    }

    .k-readonly {
        color: gray;
    }

    /* Hide the Grid header and pager during export */
    .k-pdf-export .k-grid-toolbar,
    .k-pdf-export .k-pager-wrap {
        display: none;
    }

    .k-grid .k-grid-search {
        margin-left: auto;
        margin-right: 0;
    }


    #GridID > table {
        table-layout: fixed;
    }

    .k-dialog .k-window-titlebar .k-dialog-title {
        visibility: hidden;
    }
</style>

<script>
      function dataBound() {
        this.expandRow(this.tbody.find(""tr.k-master-row"").first());
    }


    function onSelect(e) {

        var row = $(e.target);
        var dataItem = $(""#Grid"").data(""kendoGrid"").dataItem(row);
        var rnPolicy = dataItem.rnPolicy;


        if (e.item.textContent == ""Inactive"") {
         /*   e.sender.element.find("".k-menu-link:first"").attr(""href"", ""Policy/Selected?rnPolicy="" + rn");
            WriteLiteral("Policy + \"&contextmenu=Inactive\");*/\r\n            location.href = \'");
#nullable restore
#line 265 "D:\FCI\SmartMotor\Views\Policy\Inq.cshtml"
                        Write(Url.Action("Selected", "Policy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("?rnPolicy=\' + rnPolicy + \"&contextmenu=Inactive\";\r\n        }\r\n    }\r\n\r\n    function saveChanges(e) {\r\n        if (!confirm(\"คุณต้องการบันทึกข้อมูล หรือไม่?\")) {\r\n            e.preventDefault();\r\n        }\r\n    }\r\n\r\n</script>\r\n");
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
