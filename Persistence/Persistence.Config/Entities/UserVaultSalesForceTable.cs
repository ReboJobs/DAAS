using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Config.Entities
{
    public class UserVaultSalesForceTable
    {
        public int Id { get; set; }
        public int UserVaultAppDetailsId { get; set; }
        public string TableName { get; set; }
        public string Columns { get; set; }
    }
}
