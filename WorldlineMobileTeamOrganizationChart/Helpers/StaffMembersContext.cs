﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldlineMobileTeamOrganizationChart.Model.Classes.Employees;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace WorldlineMobileTeamOrganizationChart.Helpers
{
    public class StaffMembersContext : DbContext
    {
        public DbSet<StaffMember> StaffMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=staffMembers.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<Fonction>();
            modelBuilder
            .Entity<StaffMember>()
            .Property(e => e.Fonction)
            .HasConversion(converter);
        }
    }
}
