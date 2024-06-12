namespace BlazorDataAnalytics.Models
{

  class AppSettings {

    // metadata from public Azure AD application
    public const string ApplicationId = "8b29c164-355c-4ee0-96d5-5c8f927f0b04";
    public const string RedirectUri = "https://localhost:7231/";

    // metadata from confidential Azure AD application for service principal
    public const string tenantId = "94e6b5f2-d1da-4de9-a4ca-88cfdb6c3de0";
    public const string confidentialApplicationId = "8b29c164-355c-4ee0-96d5-5c8f927f0b04";
    public const string confidentialApplicationSecret = "Z6r7Q~f3YHixLNTbUDZy4Y5SEEWrKeKykjmww";
    public const string tenantSpecificAuthority = "https://login.microsoftonline.com/" + tenantId;
    public const string servicePrincipalObjectId = "fd194add-3cde-4515-b392-f14fbac4a999";
    public const string adminUser = "svc.DAaaS-uat@qualiticks.com";

    public const string dedicatedCapacityId = "";

        // connection string Tabular Object Model 
    public const string WorkspaceConnectionDevelopment = "powerbi://api.powerbi.com/v1.0/myorg/DAaaS%20-%20_Templates%20-%20DEV%2FUAT";
    public const string WorkspaceConnectionProduction = "powerbi://api.powerbi.com/v1.0/myorg/DAaaS%20-%20_Templates";

        // info required to patch SQL credentlas
        public const string sqlUserName = "sqladminuser";
    public const string sqlUserPassword = "P@ssw0rd";

    // info required to u[pdate query to redirect to ADLS
    public const string adlsFilePath = "https://qtxdaaasstorage.file.core.windows.net/";
    public const string adlsBlobAccount = "https://qtxdaaasstorage.blob.core.windows.net/";
    public const string adlsBlobContainer = "exceldata/";
    public const string adlsFileName = "SalesDataProd2.xlsx";

    // key required to configure credentials
    public const string adlsStorageKey = "9Khc2lx+oASbQhNtkv6LFl8CTlsE4ncuyDP2igaNUh/dvyFR5GtKSGKVetWlWbT+kMjQcAPEus3qO7mlg+LeHg==";

  }
}