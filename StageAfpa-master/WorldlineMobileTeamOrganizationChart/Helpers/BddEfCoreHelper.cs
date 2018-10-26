using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldlineMobileTeamOrganizationChart.Model.Classes.Employees;
using WorldlineMobileTeamOrganizationChart.ViewModel;

namespace WorldlineMobileTeamOrganizationChart.Helpers
{

   
    public class BddEfCoreHelper
    {
        #region //Requete BDD OrganizationChartViewModel
        public List<StaffMember> FiltreChiefManager()
        {
            using (var contextChiefManager = new StaffMembersContext())
            {
                var chiefManagers = from managerList in contextChiefManager.staffMember
                                    where managerList.ManagerID == 0
                                    select managerList;

                return chiefManagers.ToList();
            }
        }

        public List<StaffMember> FiltreManageMember(StaffMemberFront smcfm)
        {
            using (var contextStaffMemberManage = new StaffMembersContext())
            {
                var manageMembers = from membersmanageList in contextStaffMemberManage.staffMember
                                    where membersmanageList.ManagerID == smcfm.ID
                                    select membersmanageList;
                return manageMembers.ToList();               
            }            
        }

        public void UpdateStaffMemberBDD(StaffMember AssignedTreeView)
        {
            using (var context = new StaffMembersContext())
            {
                StaffMember sm = context.staffMember.Find(AssignedTreeView.ID);
                sm.Name = AssignedTreeView.Name;
                sm.SurName = AssignedTreeView.SurName;
                sm.Mail = AssignedTreeView.Mail;
                sm.Tel = AssignedTreeView.Tel;
                sm.Fonction = AssignedTreeView.Fonction;
                context.staffMember.Update(sm);

                context.SaveChanges();
            }
        }


        public void Delete(StaffMember AssignedTreeView)
        {
            using (var context = new StaffMembersContext())
            {
                context.staffMember.Remove(context.staffMember.Find(AssignedTreeView.ID));
                context.SaveChanges();
            }
        }

        #endregion

        #region// BDD AddStaffMembersViewModel

        public List<StaffMember> DisplayBddManager()
        {
            using (var context = new StaffMembersContext())
            {
                var manager = from m in context.staffMember
                              where m.Fonction == StaffFonction.Manager

                              select m;

              return manager.ToList();
            }           
        }

        public async void AddStaffMemberBdd(StaffMember staffMember)
        {
            using (var context = new StaffMembersContext())
            { 
                await context.AddAsync(staffMember);
                var members = context.staffMember.ToList();
                context.SaveChanges();
            }
        }
        #endregion

    }
}
