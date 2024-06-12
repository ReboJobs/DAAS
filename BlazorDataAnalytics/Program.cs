using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Persistence.Config.Entities;
using Syncfusion.Blazor;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using BlazorDataAnalytics;
using BlazorDataAnalytics.Services;
using Microsoft.Extensions.Azure;
using BlazorDataAnalytics.Services.KeyVaultManager;
using BlazorDataAnalytics.Services.UserVaultService;
using BlazorDataAnalytics.Services.ReportBugService;
using BlazorDataAnalytics.Services.IdeaService;
using BlazorDataAnalytics.Services.ApiClientService;
using BlazorDataAnalytics.Services.UserThemeSettingService;
using BlazorDataAnalytics.Services.BlobStorageService;
using BlazorDataAnalytics.Services.UserReportCardImageService;
using BlazorDataAnalytics.Services.ReportDashboardService;
using BlazorDataAnalytics.Services.UserSecurityService;
using BlazorDataAnalytics.Services.ReportService;
using BlazorDataAnalytics.Services.UserService;
using BlazorDataAnalytics.Services.BookMarkService;
using BlazorDataAnalytics.Services.LikeService;
using BlazorDataAnalytics.Services.ServicePrincipalService;
using BlazorDataAnalytics.Services.ReportThemesService;
using Azure.Identity;
using BlazorDataAnalytics.Data;
using Blazored.SessionStorage;
using Blazored.LocalStorage;
using Blazorade.Msal.Configuration;
using BlazorDataAnalytics.Services.DatasetGovernance;
using Blazored.Toast;
using BlazorDataAnalytics.Services.LogService;
using BlazorDataAnalytics.Hubs;
using BlazorDataAnalytics.Services.LoggingService;
using BlazorDataAnalytics.Services.SalesForceService;
using Microsoft.AspNetCore.SignalR;
using BlazorDataAnalytics.Hubs;

var builder = WebApplication.CreateBuilder(args);
//var builder = WebApplication.CreateBuilder(new WebApplicationOptions
//{
//    EnvironmentName = Environments.Production
//});

var connectionString = builder.Configuration.GetConnectionString("DAaaSConnection");

// Add services to the container.

builder.Services.AddDbContext<DataAnalyticsDBContext>(options =>
{
	options.UseSqlServer(connectionString,
		builder => builder.EnableRetryOnFailure());
});


// Add services to the container.
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
	.AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"))
	 .EnableTokenAcquisitionToCallDownstreamApi()
	  .AddInMemoryTokenCaches();

builder.Services.AddControllersWithViews()
	.AddMicrosoftIdentityUI();

builder.Services.AddAuthorization(options =>
{
	// By default, all incoming requests will be authorized according to the default policy
	options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddHttpClient("IP", (options) => {
	options.BaseAddress = new Uri("https://jsonip.com");
});

builder.Services.AddAzureClients(azureClientFactoryBuilder =>
{
	azureClientFactoryBuilder.AddSecretClient(
	builder.Configuration.GetSection("KeyVault"))
	// Set the credential for this client registration
	.WithCredential(new ClientSecretCredential("94e6b5f2-d1da-4de9-a4ca-88cfdb6c3de0", "8b29c164-355c-4ee0-96d5-5c8f927f0b04", "Z6r7Q~f3YHixLNTbUDZy4Y5SEEWrKeKykjmww"))
	// Configure the client options
	.ConfigureOptions(options => options.Retry.MaxRetries = 10);



});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor()
	.AddCircuitOptions(option => { option.DetailedErrors = true; })
	.AddMicrosoftIdentityConsentHandler().Services
	   .AddBlazoradeMsal((sp, o) =>
	   {
		   var root = sp.GetService<IConfiguration>();
		   var config = root.GetSection("app");
		   config.Bind(o);

		   o.DefaultScopes = new string[] { "openid", "profile" };
		   o.PostLogoutUrl = "/loggedout";
		   o.RedirectUrl = "/login";
		   o.InteractiveLoginMode = InteractiveLoginMode.Redirect;
		   o.TokenCacheScope = TokenCacheScope.Persistent;
		   
	   })
; 
    
builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });

builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddSignalR();
//services
builder.Services.AddSingleton(_ => builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IReportBugService,ReportBugService>();
builder.Services.AddScoped<IIdeaService, IdeaService>();
builder.Services.AddScoped<IApiClientService, ApiClientService>();
builder.Services.AddScoped<IUserVaultService, UserVaultService>();
builder.Services.AddScoped<IUserThemeSettingService, UserThemeSettingService>();
builder.Services.AddScoped<IUserSecurityService, UserSecurityService>();
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();
builder.Services.AddScoped<IUserReportCardImageService, UserReportCardImageService>();
builder.Services.AddScoped<IReportDashboardService, ReportDashboardService>();
builder.Services.AddScoped<IKeyVaultManager, KeyVaultManager>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBookmarkService, BookmarkService>();
builder.Services.AddScoped<FilterState>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<IDatasetGovernanceService, DatasetGovernanceService>();
builder.Services.AddScoped<IAppOwnsDataMultiTenantDbService, AppOwnsDataMultiTenantDbService>();
builder.Services.AddScoped(typeof(PowerBiServiceApi));
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IReportTheme, ReportThemeService>();
builder.Services.AddScoped<ISalesForceService, SalesForceService>();
builder.Services.AddSession(options => {
	options.IdleTimeout = TimeSpan.FromMinutes(30); 
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("Access-Control-Allow-Origin", builder =>
	 builder.AllowAnyOrigin()
				  .AllowAnyMethod()
				  .AllowAnyHeader());
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var db = new DataAnalyticsDBContext();
builder.Logging.AddProvider(new LoggingServiceLoggerProvider(
                                  new Microsoft.AspNetCore.Http.HttpContextAccessor(),db));

var app = builder.Build();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration.GetSection("SyncfusionLicense").Value);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseCors("Access-Control-Allow-Origin");
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapHub<ChatHub>("/chatHub");

app.Run();
