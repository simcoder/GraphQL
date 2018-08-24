using System;
using GOC.GraphQL.API.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GOC.GraphQL.API.Data
{
    public class DatabaseContext : DbContext, IDesignTimeDbContextFactory<DatabaseContext>
    {
        public static IConfiguration Configuration { get; set; }

        //required by EF
        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DatabaseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionsBuilder.UseNpgsql("Server=vagrant;Port=5432;Database=GOC_GraphQL;Username=goc_postgres;Password=Robins01");

            return new DatabaseContext(optionsBuilder.Options);
        }
    }
}
