using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldlineMobileTeamOrganizationChart.Model.Classes.Employees;

namespace WorldlineMobileTeamOrganizationChart.Helpers
{
    public class StaffMembersContext : DbContext
    {
        public DbSet<StaffMember> StaffMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=staffMembers.db");
        }
    }
}
