#pragma checksum "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7eb2f20fbf20f04a777c2398fd7471961151bde2"
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
#line 1 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using Azure.Security.KeyVault.Secrets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using BlazorDataAnalytics.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using BlazorDataAnalytics.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using BlazorDataAnalytics.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using BlazorDataAnalytics.Services.BlobStorageService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using Microsoft.Azure.KeyVault;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using Microsoft.Azure.KeyVault.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using Microsoft.IdentityModel.Clients.ActiveDirectory;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
using BlazorDataAnalytics.Services.Utility.FileUtility;

#line default
#line hidden
#nullable disable
    public partial class UploadCardPictureDialog : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Syncfusion.Blazor.Popups.SfDialog>(0);
            __builder.AddAttribute(1, "Target", "#target");
            __builder.AddAttribute(2, "Width", "1400px");
            __builder.AddAttribute(3, "ShowCloseIcon", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 15 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                                         true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "AllowPrerender", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 15 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                                                                                         true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(5, "IsModal", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 15 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                                                                                                        true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(6, "EnableResize", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 15 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                                                                                                                            true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "AllowDragging", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 15 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                                                                                                                                                 true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 15 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                                                              IsVisible

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "VisibleChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => IsVisible = __value, IsVisible))));
            __builder.AddAttribute(10, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Popups.DialogTemplates>(11);
                __builder2.AddAttribute(12, "Header", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(13, "Upload Card Picture");
                }
                ));
                __builder2.AddAttribute(14, "Content", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenElement(15, "div");
                    __builder3.AddAttribute(16, "class", "modal-content");
                    __builder3.OpenElement(17, "div");
                    __builder3.AddAttribute(18, "class", "modal-header");
                    __builder3.OpenElement(19, "button");
                    __builder3.AddAttribute(20, "type", "button");
                    __builder3.AddAttribute(21, "class", "close");
                    __builder3.AddAttribute(22, "aria-label", "Close");
                    __builder3.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 22 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                                                                 CloseDialog

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddMarkupContent(24, "<span aria-hidden=\"true\">&times;</span>");
                    __builder3.CloseElement();
                    __builder3.CloseElement();
                    __builder3.AddMarkupContent(25, "\r\n             ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Spinner.SfSpinner>(26);
                    __builder3.AddAttribute(27, "Visible", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 26 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                       showSpinner

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(28, "VisibleChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => showSpinner = __value, showSpinner))));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(29, "\r\n            ");
                    __builder3.OpenComponent<Syncfusion.Blazor.Inputs.SfUploader>(30);
                    __builder3.AddAttribute(31, "ID", "UploadFiles");
                    __builder3.AddAttribute(32, "AllowedExtensions", ".png, .jpg, .jpeg, .img");
                    __builder3.AddAttribute(33, "AllowMultiple", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 28 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                                                                                                    false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(34, "AutoUpload", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 28 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                                                                                                                     false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(35, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<Syncfusion.Blazor.Inputs.UploaderAsyncSettings>(36);
                        __builder4.AddAttribute(37, "SaveUrl", "api/File/UploadCardPicture");
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(38, "\r\n                ");
                        __builder4.OpenComponent<Syncfusion.Blazor.Inputs.UploaderEvents>(39);
                        __builder4.AddAttribute(40, "FileSelected", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Syncfusion.Blazor.Inputs.SelectedEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Syncfusion.Blazor.Inputs.SelectedEventArgs>(this, 
#nullable restore
#line 30 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                                               OnFileSelected

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.AddComponentReferenceCapture(41, (__value) => {
#nullable restore
#line 28 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
                              UploadObj = (Syncfusion.Blazor.Inputs.SfUploader)__value;

#line default
#line hidden
#nullable disable
                    }
                    );
                    __builder3.CloseComponent();
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
#line 38 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UploadCardPictureDialog.razor"
       
    [CascadingParameter]
    private BlazoredModalInstance _modalInstance { get; set; }

    [CascadingParameter]
    public IModalService Modal { get; set; }

    [Parameter]
    public int reportDBID { get; set; }

    SfUploader UploadObj; 

    private bool showSpinner { get; set; }

    [Parameter]
    public bool refreshParent { get; set; } = false;

    [Parameter]
    public EventCallback<bool> RefreshPageEventCallBack { get; set; }

    public bool IsVisible { get; set; } = false;

    private void Cancel()
    {
               CloseDialog();
    }

    private async Task Close()
    {
               CloseDialog();
    }

    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
    }


    private void OnFileSelected(SelectedEventArgs args) 
    {
        args.CustomFormData = new List<object> { new { ReportDBID = reportDBID.ToString() } }; 
    } 
     public async Task OpenDialog()
    {
        this.IsVisible = true;
        this.refreshParent = false;
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        StateHasChanged();
    }
  public void CloseDialog()
    {
        this.IsVisible = false;
        this.StateHasChanged();
    }
    private void OnSubmitHandler()
    {
        RefreshPageEventCallBack.InvokeAsync(this.refreshParent);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IBlobStorageService _blobStoreageServices { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
