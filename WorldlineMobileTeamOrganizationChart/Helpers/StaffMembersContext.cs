using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldlineMobileTeamOrganizationChart.Model.Classes.Employees;

namespace WorldlineMobileTeamOrganizationChart.Helpers
{
    class StaffMembersContext : DbContext
    {
        public DbSet<StaffMember> staffMembers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=staffMembers.db");
        }
    }
}
