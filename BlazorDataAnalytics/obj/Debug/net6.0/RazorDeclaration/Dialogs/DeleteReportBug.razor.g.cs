// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#line 1 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBug.razor"
using BlazorDataAnalytics.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBug.razor"
using BlazorDataAnalytics.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBug.razor"
using BlazorDataAnalytics.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBug.razor"
using BlazorDataAnalytics.Services.ReportBugService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBug.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
    public partial class DeleteReportBug : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 31 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\DeleteReportBug.razor"
       

    [CascadingParameter]
    private BlazoredModalInstance _modalInstance { get; set; }

    [CascadingParameter]
    public IModalService Modal { get; set; }

    [Parameter]
    public int reportBugId { get; set; } = 0;

    private void Cancel()
    {
        _modalInstance.CancelAsync();
    }

    private async Task Close()
    {
        await _modalInstance.CloseAsync();
    }

    private async Task DeleteReportBugId()
    {

        if(reportBugId > 0)
        {
            await _reportBugService.DeleteReportBugAsync(reportBugId);
        }

        await _modalInstance.CloseAsync(ModalResult.Ok<int>(reportBugId));
    }



#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IReportBugService _reportBugService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
