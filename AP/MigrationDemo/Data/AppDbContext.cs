using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MigrationDemo.Models;

namespace MigrationDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("MigrationDemoDB")
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}