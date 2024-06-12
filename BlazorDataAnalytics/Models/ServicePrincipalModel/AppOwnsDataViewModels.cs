﻿using Microsoft.PowerBI.Api.Models;
using Persistence.Config.Entities;

namespace BlazorDataAnalytics.Models
{

  public class EmbeddedReportViewModel {
    public string ReportId;
    public string Name;
    public string EmbedUrl;
    public string Token;
    public string TenantName;
  }

  public class CustomerTenantDetails : ServicePrincipalTenant
    {
    public IList<Report> Reports { get; set; }
    public IList<Dataset> Datasets { get; set; }
    public IList<GroupUser> Members { get; set; }
  }

}
