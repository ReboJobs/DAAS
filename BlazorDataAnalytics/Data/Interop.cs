using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorDataAnalytics.Data
{
	public static class Interop
	{
        internal static ValueTask<object> CreateReport(
            IJSRuntime jsRuntime,
            ElementReference reportContainer,
            string accessToken,
            string embedUrl,
            string embedReportId,
            string _paramEditable = "false",
            string fullscreen = "false"
            )
        {
            return jsRuntime.InvokeAsync<object>(
                "ShowMyPowerBI.showReport",
                reportContainer,
                accessToken,
                embedUrl,
                embedReportId,
                _paramEditable,
                fullscreen
                );

        }
        internal static ValueTask<object> CaptureViews(
            IJSRuntime jsRuntime,
            ElementReference reportContainer,
            string accessToken,
            string embedUrl,
            string embedReportId,
            string _paramEditable = "false",
            string fullscreen = "false"
            )
        {
            return jsRuntime.InvokeAsync<object>(
                "ShowMyPowerBI.captureViews",
                reportContainer,
                accessToken,
                embedUrl,
                embedReportId,
                _paramEditable,
                fullscreen
                );

        }
        internal static ValueTask<object> ApplyState(
       IJSRuntime jsRuntime,
       string state
       )
        {
            return jsRuntime.InvokeAsync<object>(
                "ShowMyPowerBI.applyState",

                state
                );
        }
        internal static  ValueTask<object> ApplyTheme(
        IJSRuntime jsRuntime,
        string theme
        )
        {
            return  jsRuntime.InvokeAsync<object>(
                "ShowMyPowerBI.applyTheme",
                TimeSpan.FromMinutes(1),
                theme
                );
        }

        internal static ValueTask<object> GetViews(
        IJSRuntime jsRuntime,
        ElementReference reportContainer,
        string accessToken,
        string embedUrl,
        string embedReportId,
        string _paramEditable = "false",
        string fullscreen = "false"
        )
        {
            return jsRuntime.InvokeAsync<object>(
                "ShowMyPowerBI.getBookmarks",
                reportContainer,
                accessToken,
                embedUrl,
                embedReportId,
                _paramEditable,
                fullscreen
                );

        }

        internal static ValueTask<object> CreateDashboard(
            IJSRuntime jsRuntime,
            ElementReference reportContainer,
            string accessToken,
            string embedUrl,
            string embedReportId,
            string fullscreen = "false"
            )
        {
            return jsRuntime.InvokeAsync<object>(
                "ShowMyPowerBI.showDashboard",
                reportContainer,
                accessToken,
                embedUrl,
                embedReportId,
                fullscreen
                );

        }
        internal static ValueTask<object> focustInput(
            IJSRuntime jsRuntime,
           string element
            )
                {
                    return jsRuntime.InvokeAsync<object>(
                        "focusInput",element
                        );

                }
    }
}
