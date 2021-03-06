#pragma checksum "D:\FCI\SmartMotor\Views\Main\page.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7aa444348dbf6c091a561206abe30cbff56d6434"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Main_page), @"mvc.1.0.view", @"/Views/Main/page.cshtml")]
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
#line 2 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
using Kendo.Mvc.UI;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7aa444348dbf6c091a561206abe30cbff56d6434", @"/Views/Main/page.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ca574c0602a6c6e24c17df23a182afc2df1b9ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Main_page : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
  
    ViewBag.Title = "GPS Stock";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<br />
<h5 class=""text-info"">ข้อมูล GPS Stock</h5>
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

<div class=""row"">
    <div class=""col-lg-4 col-md-4 col-sm-8"">
        ");
#nullable restore
#line 23 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
    Write(Html.Kendo().NumericTextBox<int>()
        .Name("UseCarKM")
        .Format("n0")
        .Min(1)
        .Step(1)
        .Max(50)
        .Value(1)
        .Placeholder("จำนวนอุปกรณ์ที่ต้องการเพิ่ม")
        .HtmlAttributes(new
        {
        style = "width: 100%;font-family: DB-Ozone-X; font-size:14pt;color:#000000",
        title = "numeric" ,
        required = "required",
        validationmessage = "จำนวนอุปกรณ์ที่ต้องการเพิ่ม"
        })
        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n     </div>\r\n    <div class=\"col-lg-4 col-md-4 col-sm-4\">\r\n        <button id=\"confirmBtn\" class=\"k-button\">ตกลง</button>\r\n");
            WriteLiteral("    </div>\r\n    </div>\r\n\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 50 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
    Write(Html.Kendo().DataSource<SmartMotor.Models.GpsInfo>()
        .Name("GridDataSource")
        .Ajax( dataSource => {
            dataSource
                .Batch(true)
                .Model(model =>
                {
                    model.Id(p => p.SID);
                    model.Field(p => p.SID).Editable(false);
                    model.Field(p => p.Gps_Register).Editable(false);
                    model.Field(p => p.UseDate).Editable(false);
                    model.Field(p => p.OrderPerfixID).Editable(false);
                    model.Field(p => p.GpsStatus).DefaultValue(
                    ViewData["defaulStatus"] as SmartMotor.Models.GpsStatus);
                })
                .Read(read => read.Action("Gps_Read", "Main"))
                .Create("Gps_Create", "Main")
                .Update("Gps_Update", "Main")
                .PageSize(10)
                .Events(e => e.RequestEnd("onRequestEnd"));
        })
        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n    ");
#nullable restore
#line 74 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
Write(Html.Kendo().ContextMenu()
    .Name("contextmenu")
    .Target("#Grid")
    .Filter("tr[role='row']")
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
        items.Add().Text("Active");
        items.Add().Text("InActive");
    })
    .Events(e => e.Select("onSelect"))
);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


    <script>
    function onSelect(e) {

        var grid = $(""#Grid"").data(""kendoGrid"");
        var model = grid.dataItem(e.target);
        var GpsId = model.GpsId;

        switch ($(e.item).children("".k-link"").text()) {
            case ""Active"":
                {
                    var data = model.GpsId + '|Active';

                    var url = '");
#nullable restore
#line 107 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
                          Write(Url.Action("ChangeGpsStatus", "Main", new { gpsid = "data"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'
                    url = url.replace(""data"", data);
                    location.href = url;
                    break;
                }
            case ""InActive"":
                {
                    var data = model.GpsId + '|InActive';


                    var url = '");
#nullable restore
#line 117 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
                          Write(Url.Action("ChangeGpsStatus", "Main", new { gpsid = "data"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"'
                    url = url.replace(""data"", data);
                    location.href = url;
                    break;
                }
        }
    }

    </script>

    <div class=""row"">
        <div class=""col-md-12 col-lg-12"">
            ");
#nullable restore
#line 129 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
        Write(Html.Kendo().Grid<SmartMotor.Models.GpsInfo>()
            .Name("Grid")
            .Columns(columns => {
                columns.Bound(o => o.SID).Width(100).Title("No.").Groupable(false).HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.GpsId).Title("Gps ID").Width(180).HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(ftb => ftb.Cell(cell => cell.ShowOperators(false)));

                columns.Bound(o => o.GpsStatus.Status).Title("GPS Status").Width(180).HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(ftb => ftb.Cell(cell => cell.ShowOperators(false)));


                //columns.Bound(o => o.GpsStatus.Status).Title("GPS Status").EditorTemplateName("ClientStatusEditor").ClientTemplate("#=templateCell(data)#").Width(180).HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(filterable => filterable.UI("GpsStatusFilter"));

                columns.Bound(o => o.Gps_Register).Title("Gps Register").Width(120).Format("{0:dd/MM/yyyy}").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.UseDate).Title("Use Register").Width(120).Format("{0:dd/MM/yyyy}").HeaderHtmlAttributes(new { style = "text-align: center;" }).Filterable(false);

                columns.Bound(o => o.OrderPerfixID).Title("Invoice No.").HeaderHtmlAttributes(new { style = "text-align: center;" }).Width(180).Filterable(ftb => ftb.Cell(cell => cell.Operator("contains").SuggestionOperator(FilterType.Contains)));
            })
              .Pageable(pager => pager
                    .Numeric(true)
                    .Info(true)
                    .PageSizes(true)
                    .PreviousNext(true)
                    .Refresh(true)
                    .ButtonCount(5)
                    .AlwaysVisible(false).PageSizes(new int[] { 5, 10, 20, 100, 5000 })
                )
              .ToolBar(t =>
              {
                  t.Create();
                  t.Save();
              }
              )
            .Editable(editable => editable.Mode(GridEditMode.InCell))
            .Mobile()
            .Navigatable()
                  .HtmlAttributes(new
                  {
                      style = "width: 100%;font-family: DB-Ozone-X; font-size:14pt;"
                  })
            .Sortable(sortable => sortable.AllowUnsort(false))
              .Filterable(filterable => filterable
                .Extra(false)
                .Operators(operators => operators
                        .ForString(str => str.Clear()
                        .Clear()
                        .Contains("Contains")
                        .StartsWith("Starts with")
                    ))
                )
             .DataSource("GridDataSource")
            .Resizable(resize => resize.Columns(true))
        );

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n\r\n    <div id=\"showGpsmodal\" class=\"modal fade\" tabindex=\"-1\" role=\"dialog\">\r\n        <div class=\"modal-dialog\" role=\"document\" style=\"max-width:auto; max-height:auto\">\r\n            <div class=\"modal-content\">\r\n");
#nullable restore
#line 189 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
                  
                    Html.RenderPartial("_GpsfPartialView");
                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
    </div>


    <style>
        .modal {
        padding: 0 !important;
        }

    /*    .modal-dialog {
        width: 100%;
        max-width: none;
        height: 100%;
        margin: 0;
        }


        .modal-content {
        height: 100%;
        border: 0;
        border-radius: 0;
        }*/

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

        /*   #Grid .k-grid-header .k-header {
        font-weight: bold;
        }
        */
        #GridID > table {
        table-layout: fixed;
        }

        .k-dialog .k-window-titlebar .k-dialog-t");
            WriteLiteral("itle {\r\n        visibility: hidden;\r\n        }\r\n    </style>\r\n\r\n\r\n    <script type=\"text/javascript\">\r\n\r\n\r\n    function GpsStatusFilter(element) {\r\n    element.kendoDropDownList({\r\n        dataSource: {\r\n            transport: {\r\n                read: \"");
#nullable restore
#line 257 "D:\FCI\SmartMotor\Views\Main\page.cshtml"
                  Write(Url.Action("GpsMenuCustomization_Status"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"""
            }
        },
        optionLabel: ""--เลือก--""
    });
    }

    function templateCell(data) {
        var template = """";

        if (data.dirtyFields.GpsStatus) {
            template += ""<span class='k-dirty'></span>""
        }
        template += data.GpsStatus.Status_Code;

        return template;
    }

    function onSort(e) {
        var gridData = e.sender.dataSource.data()
        gridData.forEach(function (element) {
            if (!element.ProductName) {
                e.preventDefault()
            }
        });
    }

    function saveChanges(e) {
        if (!confirm(""คุณต้องการบันทึกข้อมูล หรือไม่?"")) {
            e.preventDefault();
        }
        }

        $(""#confirmBtn"").on(""click"", function () {
            kendo.confirm(""คุณต้องการเพิ่มอุปกรณ์ GpsID หรือไม่?"").then(function () {
                kendo.alert(""You chose the Ok action."");
            }, function () {
                kendo.alert(""You chose to Cancel action."");
      ");
            WriteLiteral("      });\r\n        });\r\n\r\n    </script>\r\n");
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
