using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorldlineMobileTeamOrganizationChart.Helpers;
using WorldlineMobileTeamOrganizationChart.Model.Classes.Employees;
using WorldlineMobileTeamOrganizationChart.View;
using WorldlineMobileTeamOrganizationChart.ViewModel;


namespace WorldlineMobileTeamOrganizationChart.ViewModel
{
    class OrganizationChartViewModel:BindableBaseViewModel
    {
        #region //propiétés
        
        private List<StaffMemberFront> _ChiefManagersListFront;
        private List<StaffMemberFront> _StaffMembersListFront;
        private List<StaffMember> _ChiefManagersList;
        private List<StaffMember> _ManagersList;
        private List<StaffMemberFront> _ManagersListFront;
        private List<StaffMember> _StaffMembersList;

        private string _Surname;
        private string _Name;
        private string _Mail;
        private string _Tel;
        private StaffFonction _GetFonction;
        




        public string Surname { get => _Surname; set { _Surname = value; RaisePropertyChanged(nameof(Surname)); } }
        public string Name { get => _Name; set { _Name = value; RaisePropertyChanged(nameof(Name)); } }
        public string Mail { get => _Mail; set { _Mail = value; RaisePropertyChanged(nameof(Mail)); } }
        public string Tel { get => _Tel; set { _Tel = value; RaisePropertyChanged(nameof(Tel)); } }
        public StaffFonction GetFonction { get => _GetFonction; set { _GetFonction = value; RaisePropertyChanged(nameof(GetFonction)); } }
        public List<StaffMember> ChiefManagersList { get => _ChiefManagersList; set { _ChiefManagersList = value;RaisePropertyChanged(nameof(ChiefManagersList)); } }
        public List<StaffMemberFront> ChiefManagersListFront { get => _ChiefManagersListFront; set { _ChiefManagersListFront = value;RaisePropertyChanged(nameof(ChiefManagersList)); } }
        public List<StaffMemberFront> StaffMembersListFront { get => _StaffMembersListFront; set { _StaffMembersListFront = value; RaisePropertyChanged(nameof(StaffMembersListFront)); } }
        public List<StaffMember> StaffMembersList { get => _StaffMembersList; set { _StaffMembersList = value;RaisePropertyChanged(nameof(StaffMembersList)); } }
        public List<StaffMember> ManagersList { get => _ManagersList; set { _ManagersList = value;RaisePropertyChanged(nameof(ManagersList)); } }
        public List<StaffMemberFront> ManagersListFront { get => _ManagersListFront; set { _ManagersListFront = value;RaisePropertyChanged(nameof(ManagersListFront)); } }

        #endregion





        public ICommand CommandAddStaffMembers { get; private set; }
        

        public OrganizationChartViewModel()
        {

            using (var context = new StaffMembersContext())
            {
                context.Database.EnsureCreated();
            }

            







            #region//Filtrage des données


            

            


            using (var contextChiefManager = new StaffMembersContext())
            {
                var chiefManagers = from managerList in contextChiefManager.staffMember
                                     where managerList.ManagerID == 0
                                     select managerList;

                ChiefManagersList = chiefManagers.ToList();

                ChiefManagersListFront = new List<StaffMemberFront>();
                foreach(StaffMember sm in ChiefManagersList)
                {
                    ChiefManagersListFront.Add(sm.convertToStaffMemberFront(sm));                    
                }
                

                contextChiefManager.SaveChanges();
            }


            using (var contextAllStaffMember = new StaffMembersContext())
            {
                var manageMembers = from membersmanageList in contextAllStaffMember.staffMember
                                 where membersmanageList.ManagerID == membersmanageList.ID 
                                 select membersmanageList;
                 ManagersList= manageMembers.ToList();
                
                foreach (StaffMember smf in ManagersList)
                {
                    ChiefManagersList.Add();
                }
            }






            #endregion

            CommandAddStaffMembers = new RelayCommand(OpenWindowsAddStaffMembers);


        }

       public void OpenWindowsAddStaffMembers()
       {


            AddStaffMembersView addStaffMembersView = new AddStaffMembersView();
            
            addStaffMembersView.Show();
            

       }


        public void getStaffMembersNotChiefManager()
        {
            using (var contextAllStaffMember = new StaffMembersContext())
            {
                var allMembers = from membersList in contextAllStaffMember.staffMember
                                 where membersList.ManagerID != 0
                                 select membersList;
                StaffMembersList = allMembers.ToList();

                foreach (StaffMember allMembersList in StaffMembersList)
                {
                    ChiefManagersListFront.Add(allMembersList.convertToStaffMemberFront(allMembersList));
                }
            }
        }
    }
}
