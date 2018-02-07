using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Core.Domain;

namespace Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Post>()
                .HasMany(p => p.Tags);

            base.OnModelCreating(model);
        }
    }
}
