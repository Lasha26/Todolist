using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using System.Data.Entity;

namespace Todo.Domain.Repository
{
    public class EFDbContext: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EFDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Do> DO { get; set; }
    }
}
