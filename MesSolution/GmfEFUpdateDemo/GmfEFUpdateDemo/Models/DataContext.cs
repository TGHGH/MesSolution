﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Gmf.Demo.EFUpdate.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("default")
        {

        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasMany(m => m.Roles).WithRequired(n => n.Department);
            modelBuilder.Entity<Role>().HasMany(m => m.Members).WithMany(n => n.Roles);
        }
    }
}
