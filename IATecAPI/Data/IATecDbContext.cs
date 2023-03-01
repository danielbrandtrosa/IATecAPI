using IATecAPI.Data.Map;
using IATecAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace IATecAPI.Data
{
    public class IATecDbContext : DbContext
    {
        public IATecDbContext(DbContextOptions<IATecDbContext> options) : base(options)
        {
        }

        public DbSet<SellerModel> Sellers { get; set; }
        public DbSet<SelModel> Sels { get; set; }
        public DbSet<SelItemModel> SelItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SellerMap());
            modelBuilder.ApplyConfiguration(new SelMap());
            //modelBuilder.ApplyConfiguration(new SellerMap());
            /*modelBuilder.Entity<SelItemModel>().Property(e => e.Price).HasPrecision(24);*/
            

            base.OnModelCreating(modelBuilder);
        }

        //Migration
        // Add-Migration initialDB -Context IATecDbContext
        // Update-Database -Context IATecDbContext
        //
        // Add-Migration VinculoTarefaUsuario -Context IATecDbContext
    }
}
