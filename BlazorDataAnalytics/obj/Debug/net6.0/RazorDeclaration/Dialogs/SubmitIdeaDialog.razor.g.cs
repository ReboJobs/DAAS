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
#line 1 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
using BlazorDataAnalytics.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
using BlazorDataAnalytics.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
using BlazorDataAnalytics.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
using BlazorDataAnalytics.Services.IdeaService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
using Microsoft.WindowsAzure.Storage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
using Microsoft.WindowsAzure.Storage.Auth;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
using Microsoft.WindowsAzure.Storage.Blob;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
using BlazorDataAnalytics.Services.BlobStorageService;

#line default
#line hidden
#nullable disable
    public partial class SubmitIdeaDialog : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 91 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\SubmitIdeaDialog.razor"
       

    SfRichTextEditor ideaModelObj;
    SfUploader UploadObj; 
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.OrderedList },
        new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo }
    };
    [CascadingParameter]
    private BlazoredModalInstance _modalInstance { get; set; }

    [CascadingParameter]
    public IModalService Modal { get; set; }
    private readonly string imageContainer = "images";
    [Parameter]
    public int ideaId { get; set; } = 0;

    [Parameter]
    public string title { get; set; }

    [Parameter]
    public string description { get; set; }
    [Parameter]
    public string imagedesc { get; set; }
    [Parameter]
    public string submittedBy { get; set; }

    [Parameter]
    public int totalVotes { get; set; }

    private IdeaModel ideaModel { get; set; } = new IdeaModel();

    private bool enableControl { get; set; } = true;

    [Parameter]
    public bool refreshParent { get; set; } = false;

    [Parameter]
    public EventCallback<bool> RefreshPageEventCallBack { get; set; }

    public bool IsVisible { get; set; } = false;
    public async Task OpenDialog(int _ideaId, string _title,  string _description,string _imagedesc, string _submittedBy, int _totalVotes)
    {
        this.IsVisible = true;
        this.refreshParent = false;
        this.ideaId = _ideaId;
        this.title=_title;
        this.description = _description;
        this.imagedesc = _imagedesc;
        this.submittedBy = _submittedBy;
        this.totalVotes = _totalVotes;

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if(ideaId > 0)
        {
            ideaModel = new IdeaModel
            {
                Id = ideaId,
                Title = title,
                Description = description += "<img src='" +imagedesc+ "'/>",

            };
            enableControl = user?.Identity?.Name == submittedBy;
        }



        StateHasChanged();
    }

    public void OnImageSelectedHandler(SelectedEventArgs args)
    {
        var x = args;
    }

    public void BeforeUploadImageHandler(ImageUploadingEventArgs args)
    {
        var x = args;
    }
    public void OnImageUploadSuccessHandler(ImageSuccessEventArgs args)
    {
        var x = args;
    }
    public void CreatedHandler(Object args)
    {
        var x = args;
    }
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
        //var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        //var user = authState.User;

        //if(ideaId > 0)
        //{
        //    ideaModel = new IdeaModel
        //    {
        //        Id = ideaId,
        //        Title = title,
        //        Description = description += "<img src='" +imagedesc+ "'/>",

        //    };
        //}

        //enableControl = user?.Identity?.Name == submittedBy;

        //StateHasChanged();
    }


    public async Task Submit(EditContext context)
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        bool isValid = context.Validate();
        await UploadObj.UploadAsync();
        if (isValid)
        {
            Console.WriteLine(this.ideaModelObj.Value);
            ideaModel.SubmittedBy = user?.Identity?.Name;
            ideaModel.DateCreated = DateTime.Now;
            ideaModel.Description = ideaModelObj.Value;
            ideaModel = await _ideaService.UpsertIdeasAsync(ideaModel);
            this.refreshParent = true;
            this.OnSubmitHandler();
            CloseDialog();

        }
        else
        {
            // Form has invalid inputs.
        }


    }
    //public async Task OnChangeUpload(UploadChangeEventArgs args) 
    //{ 
    //    var authState =  AuthenticationStateProvider.GetAuthenticationStateAsync();
    //    var user = authState.Result.User;

    //    foreach (var file in args.Files) 
    //    {      
    //        byte[] bytes = file.Stream.ToArray(); 

    //        var fileUploadModel = new FileUploadModel
    //            {
    //                FileName = file.FileInfo.Name,
    //                FileMimeType = file.FileInfo.MimeContentType,
    //                FileByte = bytes,
    //                Container = imageContainer,
    //                SubDirectory = user?.Identity?.Name,
    //            };

    //        string imageBlobUrl = _blobStorageService.UploadFileToBlob(fileUploadModel).Result;
    //        _ = _ideaService.UpsertIdeasImageBlobUrlAsync(ideaModel.Id, imageBlobUrl);
    //    }
    //} 

    public async Task OnChangeUpload(UploadChangeEventArgs args) 
    { 
        var authState =  AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.Result.User;
        foreach (var file in args.Files) 
        { 
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=storageaccountlanz9402;AccountKey=w/99ADayKZqqXlj2oP7g/RJUGMadxsKh/KUW8WQr1SQypKKqRNn5pXANZMQuuzj4BqEOhX98Ga8idLP45mnNhQ==;EndpointSuffix=core.windows.net");
            var blobClient = cloudStorageAccount.CreateCloudBlobClient(); 
            var container = blobClient.GetContainerReference("images");
            await container.CreateIfNotExistsAsync(); 
            await container.SetPermissionsAsync(new BlobContainerPermissions() 
            { 
                PublicAccess = BlobContainerPublicAccessType.Blob 
            });
            string Filename = this.GenerateFileName(file.FileInfo.Name,user.Identity.Name);
            var blob = container.GetBlockBlobReference(Filename); 
            blob.Properties.ContentType = file.FileInfo.MimeContentType;
            byte[] bytes = file.Stream.ToArray();
            await blob.UploadFromByteArrayAsync(bytes, 0, bytes.Length);
            string url = blob.Uri.AbsoluteUri;

             _ = _ideaService.UpsertIdeasImageBlobUrlAsync(ideaModel.Id, url);
        } 
    }
    private string GenerateFileName(string fileName, string subDirectory)
    {
        string strFileName = string.Empty;
        string[] strName = fileName.Split('.');
        strFileName = subDirectory + "/" + DateTime.Now.ToUniversalTime().ToString("yyyyMMdd\\THHmmssfff") + "." + strName[strName.Length - 1];
        return strFileName;
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
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IBlobStorageService _blobStorageService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IIdeaService _ideaService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
