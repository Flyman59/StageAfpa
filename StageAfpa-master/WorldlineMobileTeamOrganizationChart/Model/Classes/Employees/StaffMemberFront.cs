using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldlineMobileTeamOrganizationChart.Model.Classes.Employees
{
    public class StaffMemberFront
    {
        public int ID { get; set; }
        public string Mail { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public StaffFonction Fonction { get; set; }
        public int? ManagerID { get; set; }
        public List<StaffMember> staffMembers { get; set; }


        
    }
}
