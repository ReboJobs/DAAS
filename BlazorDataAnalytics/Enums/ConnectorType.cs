using System;
using System.ComponentModel;
using System.Reflection;


namespace BlazorDataAnalytics.Enums
{
    public enum EnumConnectorType: byte
    { 
        [Description("Oauth")]
        Oauth = 1,
        [Description("SQL")]
        SQL = 2,
        [Description("CSV")]
        CSV = 3,
    }


}