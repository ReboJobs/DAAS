#pragma checksum "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6bec8a74e4c5d8b29c0751bb78cd140c7cfb287"
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
#line 24 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\_Imports.razor"
using BlazorDataAnalytics.Dialogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using BlazorDataAnalytics.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using BlazorDataAnalytics.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using BlazorDataAnalytics.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using BlazorDataAnalytics.Services.ReportBugService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using BlazorDataAnalytics.Services.UserThemeSettingService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using System.Threading;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using Syncfusion.Blazor.DropDowns;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
using Microsoft.AspNetCore.WebUtilities;

#line default
#line hidden
#nullable disable
    public partial class UserSettings : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<style> \r\n    .text-multiline textarea{ \r\n        height: 400px !important; \r\n    } \r\n    .theme-title\r\n    {\r\n        background: #f7f7f7;\r\n        padding: 5px;\r\n        text-transform: uppercase;\r\n        font-size: 12px;\r\n        font-weight: 700;\r\n    }\r\n    .theme-body\r\n    {\r\n        align-items: flex-end;\r\n        text-align: end;\r\n        margin-bottom: 10px;\r\n    }\r\n    .theme-label\r\n    {\r\n        color: #817e7e;\r\n        font-size: 12px;\r\n        font-weight: 700;\r\n    }\r\n    .btn-close\r\n    {\r\n        border: none;\r\n        background: none;\r\n        color: red;\r\n        text-transform: uppercase;\r\n        font-weight: 600;\r\n        font-size: 20px;\r\n    }\r\n    .e-colorpicker-wrapper .e-split-btn-wrapper .e-split-colorpicker.e-split-btn .e-selected-color, .e-colorpicker-container .e-split-btn-wrapper .e-split-colorpicker.e-split-btn .e-selected-color {\r\n    background-size: 8px;\r\n    border-radius: 50%;\r\n    height: 12px;\r\n    margin-top: 0;\r\n    position: relative;\r\n    width: 12px;\r\n    }\r\n   \r\n    .e-colorpicker-container .e-split-btn-wrapper .e-split-colorpicker.e-split-btn .e-selected-color .e-split-preview {\r\n    border-radius: 50px !important;\r\n    }\r\n    .e-colorpicker-container .e-split-btn-wrapper .e-split-colorpicker.e-split-btn {\r\n    font-family: initial;\r\n    line-height: 1px;\r\n    padding: 1px 5px;\r\n    background-color: transparent;\r\n    border: 1px solid #f0f1f3;\r\n    }\r\n    .e-colorpicker-wrapper .e-btn.e-icon-btn, .e-colorpicker-container .e-btn.e-icon-btn {\r\n    background-color: #fff;\r\n    border: 1px solid #f0f1f3;\r\n    color: #6c757d;\r\n    }\r\n    .logo-text\r\n    {\r\n    width: 200px;\r\n    text-align: left;\r\n    padding: 5px;\r\n    text-transform: uppercase;\r\n    font-size: 12px;\r\n    font-weight: 700;\r\n    }\r\n    .e-upload .e-file-select-wrap .e-file-drop, .e-bigger.e-small .e-upload .e-file-select-wrap .e-file-drop {\r\n    font-family: inherit;\r\n    font-size: 14px;\r\n    margin-left: 12px;\r\n    display: none !important;\r\n    }\r\n    .e-upload {\r\n    border: 1px solid #f7f7f7;\r\n    border-top: none;\r\n    }\r\n    .e-upload .e-file-select-wrap, .e-bigger.e-small .e-upload .e-file-select-wrap {\r\n    padding-top: 10px !important;\r\n    padding-left: 10px;\r\n    }\r\n    .logo\r\n    {\r\n        align-items: flex-end;\r\n        text-align: start;\r\n        margin-bottom: 10px;\r\n    }\r\n    .btn-close:focus {\r\n    outline: 0;\r\n    box-shadow: none;\r\n    opacity: 1;\r\n    }\r\n    .theme-body .e-upload {\r\n    border:none;\r\n    }\r\n    .theme-body .e-file-select-wrap\r\n    {\r\n        padding:0px !important\r\n    }\r\n   .theme-body .e-upload .e-file-select-wrap .e-file-drop {\r\n    display: none !important;\r\n    }\r\n    .bg-image\r\n    {\r\n    display: flex;\r\n    text-align: center;\r\n    margin-bottom: -35px;\r\n    margin-left: 50px;\r\n    }\r\n \r\n</style> \r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "modal fade show d-block");
            __builder.AddAttribute(3, "tabindex", "-1");
            __builder.AddAttribute(4, "role", "dialog");
            __builder.AddMarkupContent(5, "<div class=\"modal-backdrop fade show\"></div>\r\n    ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "modal-dialog");
            __builder.AddAttribute(8, "style", "z-index: 1050;max-width: 60%");
            __builder.OpenElement(9, "div");
            __builder.AddAttribute(10, "class", "modal-content");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "modal-header");
            __builder.AddMarkupContent(13, "<h5 class=\"modal-title\">Theme Settings</h5>\r\n                ");
            __builder.OpenElement(14, "button");
            __builder.AddAttribute(15, "type", "button");
            __builder.AddAttribute(16, "class", "close btn-close");
            __builder.AddAttribute(17, "aria-label", "Close");
            __builder.AddAttribute(18, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 137 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                                           Close

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(19, "<span aria-hidden=\"true\">&times;</span>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\r\n            ");
            __builder.OpenElement(21, "div");
            __builder.AddAttribute(22, "class", "modal-body");
            __builder.OpenElement(23, "div");
            __builder.AddAttribute(24, "class", "row");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "col-md-5");
            __builder.OpenElement(27, "div");
            __builder.AddMarkupContent(28, "<p class=\"theme-title\">User Logo</p>\r\n                            ");
            __builder.OpenElement(29, "div");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfUploader>(30);
            __builder.AddAttribute(31, "ID", "UploadLogo");
            __builder.AddAttribute(32, "AllowedExtensions", ".png, .jpg, .jpeg, .img");
            __builder.AddAttribute(33, "AutoUpload", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 147 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                                                                   false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.UploaderAsyncSettings>(35);
                __builder2.AddAttribute(36, "SaveUrl", "api/File/UploadUserHeaderLogo");
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n                        ");
            __builder.OpenElement(38, "div");
            __builder.AddMarkupContent(39, "<p class=\"theme-title\">Body Background Image</p>\r\n                            ");
            __builder.OpenElement(40, "div");
            __Blazor.BlazorDataAnalytics.Dialogs.UserSettings.TypeInference.CreateSfCheckBox_0(__builder, 41, 42, "Use Background Image", 43, 
#nullable restore
#line 155 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                                        userTheme.IsBackgroundImage

#line default
#line hidden
#nullable disable
            , 44, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userTheme.IsBackgroundImage = __value, userTheme.IsBackgroundImage)), 45, () => userTheme.IsBackgroundImage);
            __builder.AddMarkupContent(46, "\r\n                                 ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfUploader>(47);
            __builder.AddAttribute(48, "ID", "BackgroundImage");
            __builder.AddAttribute(49, "AllowedExtensions", ".png, .jpg, .jpeg, .img");
            __builder.AddAttribute(50, "AutoUpload", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 156 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                                                                            false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(51, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.Inputs.UploaderAsyncSettings>(52);
                __builder2.AddAttribute(53, "SaveUrl", "api/File/UploadUserBackgroundImage");
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n                      ");
            __builder.OpenElement(55, "div");
            __builder.AddAttribute(56, "class", "col-md-7");
            __builder.OpenElement(57, "div");
            __builder.AddMarkupContent(58, "<p class=\"theme-title\">Body</p>\r\n                            ");
            __builder.OpenElement(59, "div");
            __builder.AddAttribute(60, "class", "theme-body");
            __builder.AddMarkupContent(61, "<span class=\"theme-label\">Background</span>\r\n                                ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(62);
            __builder.AddAttribute(63, "ID", "BodyBackground");
            __builder.AddAttribute(64, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 169 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                                 userTheme.BackgroundColorHex

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(65, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userTheme.BackgroundColorHex = __value, userTheme.BackgroundColorHex))));
            __builder.AddAttribute(66, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userTheme.BackgroundColorHex));
            __builder.CloseComponent();
            __builder.AddMarkupContent(67, "\r\n                                   ");
            __builder.AddMarkupContent(68, "<span class=\"theme-label\">Color</span>\r\n                                ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(69);
            __builder.AddAttribute(70, "ID", "BodyFontColor");
            __builder.AddAttribute(71, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 171 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                               userTheme.BackgroundFontColorHex

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(72, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userTheme.BackgroundFontColorHex = __value, userTheme.BackgroundFontColorHex))));
            __builder.AddAttribute(73, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userTheme.BackgroundFontColorHex));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(74, "\r\n                        ");
            __builder.OpenElement(75, "div");
            __builder.AddMarkupContent(76, "<p class=\"theme-title\">Nav Bar</p>\r\n                            ");
            __builder.OpenElement(77, "div");
            __builder.AddAttribute(78, "class", "theme-body");
            __builder.AddMarkupContent(79, "<span class=\"theme-label\">Background</span>\r\n                                  ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(80);
            __builder.AddAttribute(81, "ID", "NavBar");
            __builder.AddAttribute(82, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 178 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                          userTheme.NavigationColorHex

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(83, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userTheme.NavigationColorHex = __value, userTheme.NavigationColorHex))));
            __builder.AddAttribute(84, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userTheme.NavigationColorHex));
            __builder.CloseComponent();
            __builder.AddMarkupContent(85, "\r\n                                   ");
            __builder.AddMarkupContent(86, "<span class=\"theme-label\">Color</span>\r\n                               ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(87);
            __builder.AddAttribute(88, "ID", "FontColorNavBar");
            __builder.AddAttribute(89, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 180 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                                userTheme.NavigationFontColorHex

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(90, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userTheme.NavigationFontColorHex = __value, userTheme.NavigationFontColorHex))));
            __builder.AddAttribute(91, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userTheme.NavigationFontColorHex));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(92, "\r\n                        ");
            __builder.OpenElement(93, "div");
            __builder.AddMarkupContent(94, "<p class=\"theme-title\">Dashboard</p>\r\n                            ");
            __builder.OpenElement(95, "div");
            __builder.AddAttribute(96, "class", "theme-body");
            __builder.AddMarkupContent(97, "<span class=\"theme-label\">Background</span>\r\n                                  ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(98);
            __builder.AddAttribute(99, "ID", "Dashboard");
            __builder.AddAttribute(100, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 187 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                             userTheme.DashboardColorHex

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(101, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userTheme.DashboardColorHex = __value, userTheme.DashboardColorHex))));
            __builder.AddAttribute(102, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userTheme.DashboardColorHex));
            __builder.CloseComponent();
            __builder.AddMarkupContent(103, "\r\n                                   ");
            __builder.AddMarkupContent(104, "<span class=\"theme-label\">Color</span>\r\n                                   ");
            __builder.OpenComponent<Syncfusion.Blazor.Inputs.SfColorPicker>(105);
            __builder.AddAttribute(106, "ID", "FontColorDashboard");
            __builder.AddAttribute(107, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 189 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                                       userTheme.DashboardFontColorHex

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(108, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userTheme.DashboardFontColorHex = __value, userTheme.DashboardFontColorHex))));
            __builder.AddAttribute(109, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<System.String>>>(() => userTheme.DashboardFontColorHex));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(110, "\r\n                        ");
            __builder.OpenElement(111, "div");
            __builder.AddMarkupContent(112, "<p class=\"theme-title\">Switch Themes</p>\r\n                            ");
            __builder.OpenElement(113, "div");
            __builder.AddAttribute(114, "class", "theme-body");
            __builder.OpenElement(115, "div");
            __builder.AddAttribute(116, "class", "theme-switcher");
            __builder.AddAttribute(117, "style", "width: 200px;float: right;");
            __builder.OpenComponent<Syncfusion.Blazor.DropDowns.SfDropDownList<string, ThemeDetails>>(118);
            __builder.AddAttribute(119, "DataSource", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<ThemeDetails>>(
#nullable restore
#line 197 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                                                                                              Themes

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(120, "Value", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(
#nullable restore
#line 197 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                                                          userTheme.SwitchTheme

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(121, "ValueChanged", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => userTheme.SwitchTheme = __value, userTheme.SwitchTheme))));
            __builder.AddAttribute(122, "ValueExpression", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(() => userTheme.SwitchTheme));
            __builder.AddAttribute(123, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Syncfusion.Blazor.DropDowns.DropDownListFieldSettings>(124);
                __builder2.AddAttribute(125, "Text", "Text");
                __builder2.AddAttribute(126, "Value", "ID");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(127, " \r\n                                            ");
                __builder2.OpenComponent<Syncfusion.Blazor.DropDowns.DropDownListEvents<string, ThemeDetails>>(128);
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(129, "\r\n                ");
            __builder.OpenElement(130, "div");
            __builder.AddAttribute(131, "class", "modal-footer");
            __builder.OpenComponent<Syncfusion.Blazor.Buttons.SfButton>(132);
            __builder.AddAttribute(133, "CssClass", "e-medium");
            __builder.AddAttribute(134, "OnClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 209 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                 Submit

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(135, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(136, "Apply");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(137, "\r\n                          ");
            __builder.OpenComponent<Syncfusion.Blazor.Buttons.SfButton>(138);
            __builder.AddAttribute(139, "CssClass", "e-medium");
            __builder.AddAttribute(140, "OnClick", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 210 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
                                                                 Reset

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(141, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(142, "Reset");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 216 "C:\Users\Rebo\source\repos\DAaaS\BlazorDataAnalytics\Dialogs\UserSettings.razor"
       
    [CascadingParameter]
    private BlazoredModalInstance _modalInstance { get; set; }

    private string themeName; 
    private List<ThemeDetails> Themes = new List<ThemeDetails>() { 
        new ThemeDetails(){ ID = "material", Text = "Material" }, 
        new ThemeDetails(){ ID = "bootstrap", Text = "Bootstrap" }, 
        new ThemeDetails(){ ID = "fabric", Text = "Fabric" }, 
        new ThemeDetails(){ ID = "bootstrap4", Text = "Bootstrap 4" }, 
    }; 
    public class ThemeDetails 
    { 
        public string ID { get; set; } 
        public string Text { get; set; } 
    }
        /// The switcher OnChange event handler. 
    /// </summary> 
    //public void OnThemeChange(ChangeEventArgs<string, ThemeDetails> args) 
    //{ 
    //    var theme = GetThemeName(); 
    //    if (theme != args.ItemData.ID) 
    //    { 
    //        UrlHelper.NavigateTo(GetUri(args.ItemData.ID), true); 
    //    } 
    //} 

    /// <summary> 
    /// Returns the theme name from Uri QueryString. 
    /// </summary> 
    private string GetThemeName() 
    { 
        var uri = UrlHelper.ToAbsoluteUri(UrlHelper.Uri); 
        QueryHelpers.ParseQuery(uri.Query).TryGetValue("theme", out var theme); 
        theme = theme.Count > 0 ? theme.First() : "bootstrap4"; 
        return theme; 
    } 
 
    /// <summary> 
    /// Returns the new Uri to navigate with theme changes. 
    /// </summary> 
    private string GetUri(string themeName) 
    { 
        var uri = UrlHelper.ToAbsoluteUri(UrlHelper.Uri); 
        return uri.AbsolutePath + "?theme=" + themeName; 
    } 
 
    //protected override void OnInitialized() 
    //{ 
    //    var theme = GetThemeName(); 
    //    themeName = theme.Contains("bootstrap4") ? "bootstrap4" : theme; 
    //} 
    private async Task Close()
    {
        await _modalInstance.CloseAsync();
    }
    private UserThemeSettingModel userTheme { get; set; } = new UserThemeSettingModel();
    private string userName { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {

        await GetUserThemeSetting();
        var theme = GetThemeName(); 
        themeName = theme.Contains("bootstrap4") ? "bootstrap4" : theme; 
    }

    private async Task GetUserThemeSetting()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        userName = user?.Identity?.Name ?? string.Empty;
        userTheme =  _userThemeSettingService.GetUserThemeSettings(userName) ?? new UserThemeSettingModel();
    }

    private async Task Submit()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        userTheme.UserName = userName;
        userTheme = await _userThemeSettingService.UpsertUserThemeAsync(userTheme);

       await Close();
        var timer = new Timer(new TimerCallback(_ => { uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true); }), null, 100, 100);
     
    }

   private async Task Reset()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        userTheme.UserName = userName;
        userName = user?.Identity?.Name ?? string.Empty;

        userTheme = await _userThemeSettingService.ResetUserThemes(userName);

       await Close();
        var timer = new Timer(new TimerCallback(_ => { uriHelper.NavigateTo(uriHelper.Uri, forceLoad: true); }), null, 100, 100);
     
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager UrlHelper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager uriHelper { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserThemeSettingService _userThemeSettingService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
namespace __Blazor.BlazorDataAnalytics.Dialogs.UserSettings
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateSfCheckBox_0<TChecked>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, TChecked __arg1, int __seq2, global::Microsoft.AspNetCore.Components.EventCallback<TChecked> __arg2, int __seq3, global::System.Linq.Expressions.Expression<global::System.Func<TChecked>> __arg3)
        {
        __builder.OpenComponent<global::Syncfusion.Blazor.Buttons.SfCheckBox<TChecked>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "Checked", __arg1);
        __builder.AddAttribute(__seq2, "CheckedChanged", __arg2);
        __builder.AddAttribute(__seq3, "CheckedExpression", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
