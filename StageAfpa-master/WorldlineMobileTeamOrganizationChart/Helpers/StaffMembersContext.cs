using Microsoft.EntityFrameworkCore;
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
        public DbSet<StaffMember> staffMember { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=staffMembers.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new EnumToStringConverter<StaffFonction>();

            modelBuilder
                .Entity<StaffMember>()
                .Property(e => e.Fonction)
                .HasConversion(converter);

            modelBuilder.Entity<StaffMember>()
                .HasIndex(s => new { s.Mail, s.Tel })
                .IsUnique();







        }



    }
}
