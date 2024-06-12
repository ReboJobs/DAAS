using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class UserThemeSetting
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? DashboardColorHex { get; set; }
        public string? DashboardFontColorHex { get; set; }
        public string? NavigationColorHex { get; set; }
        public string? NavigationFontColorHex { get; set; }
        public string? BackgroundColorHex { get; set; }
        public string? BackgroundFontColorHex { get; set; }
        public string? HeaderImageLogoUrl { get; set; }
        public string? BackgroundImageLogoUrl { get; set; }
        public bool? IsBackgroundImage { get; set; }
        public int? CustomerTenantId { get; set; }
        public string? SwitchTheme { get; set; }
    }
}
