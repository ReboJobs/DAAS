#pragma checksum "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "febcd36c37e67cca0c2d37a8b4f51db7d9ded102"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorDataAnalytics.Dialogs
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using BlazorDataAnalytics;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using BlazorDataAnalytics.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor.DropDowns;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor.Spinner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor.SplitButtons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor.Popups;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using System.Security.Claims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor.RichTextEditor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using BlazorDataAnalytics.Dialogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
using BlazorDataAnalytics.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
using BlazorDataAnalytics.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
using BlazorDataAnalytics.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
using BlazorDataAnalytics.Services.ReportBugService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
    public partial class DeleteReportBugDialog : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Syncfusion.Blazor.Popups.SfDialog>(0);
            __builder.AddAttribute(1, "Target", "#target");
            __builder.AddAttribute(2, "Width", "600px");
            __builder.AddAttribute(3, "ShowCloseIcon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 8 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
                                                        true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "AllowPrerender", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 8 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
                                                                                                        true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "IsModal", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 8 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
                                                                                                                       true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 8 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
                                                                             IsVisible

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "VisibleChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => IsVisible = __value, IsVisible))));
            __builder.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogTemplates>(9);
                __builder2.AddAttribute(10, "Header", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(11, "Delete Reported Bug");
                }
                ));
                __builder2.AddAttribute(12, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(13, "div");
                    __builder3.AddAttribute(14, "class", "modal-content");
                    __builder3.OpenElement(15, "div");
                    __builder3.AddAttribute(16, "class", "modal-header");
                    __builder3.OpenElement(17, "button");
                    __builder3.AddAttribute(18, "type", "button");
                    __builder3.AddAttribute(19, "class", "close");
                    __builder3.AddAttribute(20, "aria-label", "Close");
                    __builder3.AddAttribute(21, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 15 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
                                                                                 CloseDialog

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddMarkupContent(22, "<span aria-hidden=\"true\">&times;</span>");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(23, "\r\n            ");
                    __builder3.OpenElement(24, "div");
                    __builder3.AddAttribute(25, "class", "modal-body");
                    __builder3.AddMarkupContent(26, "\r\n                 Do you want to delete this Report Bug Id: ");
                    __builder3.OpenElement(27, "b");
#nullable restore
#line (20,64)-(20,75) 26 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
__builder3.AddContent(28, reportBugId);

#line default
#line hidden
#nullable disable
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(29, " ?\r\n            ");
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(30, "\r\n            ");
                    __builder3.OpenElement(31, "div");
                    __builder3.AddAttribute(32, "class", "modal-footer");
                    __builder3.OpenComponent<Syncfusion.Blazor.Buttons.SfButton>(33);
                    __builder3.AddAttribute(34, "CssClass", "e-medium");
                    __builder3.AddAttribute(35, "OnClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 23 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
                                                             async (e) => await DeleteReportBugId()

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(36, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(37, "Delete");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(38, "\r\n                    ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Buttons.SfButton>(39);
                    __builder3.AddAttribute(40, "CssClass", "e-medium e-danger");
                    __builder3.AddAttribute(41, "OnClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 24 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
                                                                    CloseDialog

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(42, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(43, "Close");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
#nullable restore
#line 30 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBugDialog.razor"
       

    [CascadingParameter]
    private BlazoredModalInstance _modalInstance { get; set; }

    [CascadingParameter]
    public IModalService Modal { get; set; }

    [Parameter]
    public int reportBugId { get; set; } = 0;
    public bool IsVisible { get; set; } = false;

    [Parameter]
    public bool refreshParent { get; set; } = false;
    [Parameter]
    public EventCallback<bool> RefreshPageEventCallBack { get; set; }

    private void Cancel()
    {
        CloseDialog();
        StateHasChanged();
    }
    public async Task OpenDialog(int id)
    {
        this.IsVisible = true;
        this.refreshParent = false;
        this.reportBugId = id;
        if(id > 0)
        {
            this.IsVisible = true;
        }
        this.StateHasChanged();
    }

    private async Task Close()
    {
              CloseDialog();
        StateHasChanged();
    }

    private async Task DeleteReportBugId()
    {

        if(reportBugId > 0)
        {
            await _reportBugService.DeleteReportBugAsync(reportBugId);
            this.refreshParent = true;
            this.OnSubmitHandler();
            CloseDialog();
        }

    }
   private void OnSubmitHandler()
    {
        RefreshPageEventCallBack.InvokeAsync(this.refreshParent);
    }
     public void CloseDialog()
    {
        this.IsVisible = false;
        this.StateHasChanged();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IReportBugService _reportBugService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
