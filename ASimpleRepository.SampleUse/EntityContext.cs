using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASimpleRepository.SampleUse
{
    public class EntityContext : DbContext
    {
        
        public EntityContext(DbConnection connection) : base(connection, true)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
