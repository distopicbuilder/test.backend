using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configurations;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configurations) : base(options)
        {
            _configurations = configurations;
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>()
                .HasOne(p => p.City);
        }

        #region DbSet
        public DbSet<City> City { get; set; }
        public DbSet<People> People { get; set; }
        #endregion

    }
}
