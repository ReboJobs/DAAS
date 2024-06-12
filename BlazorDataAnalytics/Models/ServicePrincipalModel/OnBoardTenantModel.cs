using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlazorDataAnalytics.Models.ServicePrincipalModel
{
    public class OnboardTenantModel
    {
        public string TenantName { get; set; }
        public string SuggestedDatabase { get; set; }
        public List<SelectListItem> DatabaseOptions { get; set; }
        public List<SelectListItem> ProfileOptions { get; set; }
    }
}
