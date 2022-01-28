﻿
using InventoryManagement.Domain.InventoryAgg;
using InventoryMangement.InfraStructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryMangement.InfraStructure.EFCore
{
    public class InventoryContext:DbContext
    {
        public DbSet<Inventory> Inventory { get; set; }
        public InventoryContext(DbContextOptions<InventoryContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
