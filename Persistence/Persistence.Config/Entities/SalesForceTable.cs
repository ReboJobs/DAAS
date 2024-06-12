using System;
using System.Collections.Generic;

namespace Persistence.Config.Entities
{
    public partial class SalesForceTable
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public string Columns { get; set; }
    }
}
