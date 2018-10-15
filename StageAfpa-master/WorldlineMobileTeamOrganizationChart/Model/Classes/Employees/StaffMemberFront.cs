using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldlineMobileTeamOrganizationChart.Model.Classes.Employees
{
    public class StaffMemberFront
    {
        private List<StaffMember> _MembersList;

        private StaffMember _StaffMember;

        public int IDStaffMemberFront; 
                
        public string MailStaffMemberFront { get; set; }
        
        public string SurNameStaffMemberFront { get; set; }
        
        public string NameStaffMemberFront { get; set; }
        
        public string TelStaffMemberFront { get; set; } 
        
        public StaffFonction FonctionStaffMemberFront { get; set; }

        public int? ManagerIDStaffMemberFront { get; set; }        
        public List<StaffMember> MembersList { get => _MembersList; set => _MembersList = value; }
        public StaffMember StaffMember { get => _StaffMember; set => _StaffMember = value; }

        public StaffMemberFront()
        {
            staffMemberFrontConvert(StaffMember);
            
        }

        public void staffMemberFrontConvert( StaffMember staffMember)
        {
            IDStaffMemberFront = staffMember.ID;
            MailStaffMemberFront = staffMember.Mail;
            SurNameStaffMemberFront = staffMember.SurName;
            NameStaffMemberFront = staffMember.Name;
            TelStaffMemberFront = staffMember.Tel;
            FonctionStaffMemberFront = staffMember.Fonction;
            ManagerIDStaffMemberFront = staffMember.ManagerID;
            MembersList = staffMember.staffMembers;

            
        }
            
    }
}
