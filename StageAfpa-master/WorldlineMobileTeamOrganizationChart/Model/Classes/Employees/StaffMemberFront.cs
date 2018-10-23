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
        public List<StaffMemberFront> staffMembersFront { get; set; }


        static public StaffMember convertToStaffMember(StaffMemberFront staffMemberFront)
        {
            StaffMember staffMember = new StaffMember();
            staffMember.ID = staffMemberFront.ID;
            staffMember.Mail = staffMemberFront.Mail;
            staffMember.SurName = staffMemberFront.SurName;
            staffMember.Name = staffMemberFront.Name;
            staffMember.Tel = staffMemberFront.Tel;
            staffMember.Fonction = staffMemberFront.Fonction;
            staffMember.ManagerID = staffMemberFront.ManagerID;
            return staffMember;
        }
    }
}
