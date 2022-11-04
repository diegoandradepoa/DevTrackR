﻿using DevTrackR.Controllers;
using DevTrackR.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevTrackR.Persistence
{
    public class DevTrackRContext : DbContext
    {
        public DevTrackRContext(DbContextOptions<DevTrackRContext> options)
             : base(options)   // Construtor que instancia a chamada
        {
        }

        public DbSet<Package> Packages { get; set; } // Atributos
        public DbSet<PackageUpdate> PackageUpdates { get; set; } // Atributos

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>(e =>
            {
                e.HasKey(p => p.Id);

                e.HasMany(p => p.Updates)
                .WithOne()
                .HasForeignKey(pu => pu.PakageId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<PackageUpdate>(e =>
            {
                e.HasKey(p => p.Id);
            });
        }
    }
}
// Simula um banco de dados