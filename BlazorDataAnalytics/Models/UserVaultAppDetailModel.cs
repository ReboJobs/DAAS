using System;
using System.Collections.Generic;

namespace BlazorDataAnalytics.Models
{
    public partial class UserVaultAppDetailModel
    {
        public int Id { get; set; }
        public int? UserVaultId { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public string? IdToken { get; set; }
        public string? ServerName { get; set; }
        public string? DatabaseName { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public DateTime? DateTokenExpiredUtc { get; set; }
        public string? CallBackUrl { get; set; }
        public string? DatalakeConString { get; set; }
        public string? DatalakeConStringBackup { get; set; }
        public bool IsBackUpToCustomer { get; set; }
        public bool IsStoreInQTX { get; set; }
        public string? Warehouse { get; set; }
        public string? KeepDataSecretKey { get; set; }
        public string? KeepDataStorageAccountName { get; set; }
        public string? KeepDataContainerName { get; set; }
        public bool IsKeepData { get; set; }

        public string? SecurityToken { get; set; }
        public string? APIVersion { get; set; }
        public string? Tables { get; set; }
        public string? PayLoadData { get; set; }
        public int? RecurrenceNo { get; set; }
        public string? RecurrenceDesc { get; set; }
    }
}
