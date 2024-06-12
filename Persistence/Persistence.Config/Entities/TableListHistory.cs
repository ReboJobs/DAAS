using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Config.Entities
{
    public class TableListHistory
    {
        public int Id { get; set; }
        public string? TableName { get; set; }
    }
}
