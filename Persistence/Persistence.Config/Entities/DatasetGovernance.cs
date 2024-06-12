using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Config.Entities
{
    public partial class DatasetGovernance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Criteria { get; set; }
        public string? Action { get; set; }
        public string? DatasetId { get; set; }
    }
}
