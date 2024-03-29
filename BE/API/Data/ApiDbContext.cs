﻿using WebShop.API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.API.Data
{
    public class ApiDbContext : IdentityDbContext<ApiUser>
    {
        public ApiDbContext(DbContextOptions options)
        : base(options)
        {
            SavingChanges += ApiDbContext_SavingChanges;
        }

        public DbSet<ShopItem> ShopItems { get; set; }

        //public DbSet<Company> Companies { get; set; }

        public DbSet<AuthRefreshToken> AuthRefreshTokens { get; set; }

        private void ApiDbContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            UpdateCreatedChanged();
        }

        private void UpdateCreatedChanged()
        {
            var now = DateTimeOffset.Now;
            foreach (var entry in ChangeTracker.Entries<IDatedEntity>())
            {
                var entity = entry.Entity;
                switch (entry.State)
                {
                    case EntityState.Added:
                        entity.Created = now;
                        entity.Updated = now;
                        break;

                    case EntityState.Modified:
                        entity.Updated = now;
                        break;
                }
            }

            ChangeTracker.DetectChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApiUser>()
                .HasMany(u => u.Roles)
                .WithMany("Users")
                .UsingEntity<IdentityUserRole<string>>(
                    userRole => userRole.HasOne<IdentityRole>()
                        .WithMany()
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired(),
                    userRole => userRole.HasOne<ApiUser>()
                        .WithMany()
                        .HasForeignKey(ur => ur.UserId)
                        .IsRequired());
        }
    }
}
