using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Config.Entities{

  public partial class AppProfile {
    [Key]
    public int Id { get; set; } 
    public string ProfileName { get; set; }
    public string ProfileId { get; set; }
    public bool Exclusive { get; set; }
    public DateTime Created { get; set; }
    public virtual List<ServicePrincipalTenant> Tenants { get; set; }
  }


    public partial class ServicePrincipalTenant {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string WorkspaceId { get; set; }
        public string WorkspaceUrl { get; set; }
        public string DatabaseServer { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseUserName { get; set; }
        public string DatabaseUserPassword { get; set; }
        public DateTime Created { get; set; }
        public int ProfileId { get; set; }
        public AppProfile? Profile { get; set; }
    }
  }

