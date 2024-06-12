using System;
using System.ComponentModel;
using System.Reflection;


namespace BlazorDataAnalytics.Enums
{
    public enum EnumSystem : byte
    { 
        [Description("Kronos")]
        Kronos = 1,
        [Description("Epicor")]
        Epicor = 2,
        [Description("Workday")]
        Workday = 3,
        [Description("Nurse Call")]
        NurseCall = 4,
        [Description("Chris21")]
        Chris21 = 5,
        [Description("Basware")]
        Basware = 6,
        [Description("iCare")]
        iCare = 7,
        [Description("Dynamics 365")]
        Dynamics365 = 8,
        [Description("SalesForce")]
        SalesForce = 9,
        [Description("Cornerstone")]
        Cornerstone = 10,
        [Description("Xero")]
         Xero = 11,
        [Description("Snowflake")]
        Snowflake = 12,
        [Description("eCase")]
        eCase = 13,
        [Description("Roubler")]
        Roubler = 14,
        [Description("Csv")]
        Csv = 15
    }


}