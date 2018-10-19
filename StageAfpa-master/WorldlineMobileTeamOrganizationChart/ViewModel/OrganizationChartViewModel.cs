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
        private List<StaffMember> _ChiefManagersList;        
        private StaffMember _AssignedTreeView;
       
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
        public StaffMember AssignedTreeView { get => _AssignedTreeView; set { _AssignedTreeView = value; RaisePropertyChanged(nameof(AssignedTreeView)); } }
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
                foreach(StaffMember smcfm in ChiefManagersList)
                {
                    ChiefManagersListFront.Add(smcfm.convertToStaffMemberFront(smcfm));
                }
                List<StaffMemberFront> test = new List<StaffMemberFront>();

                foreach (StaffMemberFront smcfmf in ChiefManagersListFront)
                {
                    smcfmf.staffMembersFront = DisplayStaffMemberManage(smcfmf);
                   
                }
            }
            #endregion

            CommandAddStaffMembers = new RelayCommand(OpenWindowsAddStaffMembers);


        }


        #region//Methodes
        public void OpenWindowsAddStaffMembers()
        {
            AddStaffMembersView addStaffMembersView = new AddStaffMembersView();
            
            addStaffMembersView.Show();
        }

        public List<StaffMemberFront> DisplayStaffMemberManage(StaffMemberFront smcfm)
        {
            List<StaffMemberFront> StaffMembersManageListFront = new List<StaffMemberFront>();

            using (var contextStaffMemberManage = new StaffMembersContext())
                {
                   
                        var manageMembers = from membersmanageList in contextStaffMemberManage.staffMember
                                            where membersmanageList.ManagerID == smcfm.ID
                                            select membersmanageList;
                        List<StaffMember> StaffMemberManageList = manageMembers.ToList();
                        
                        foreach (StaffMember stml in StaffMemberManageList)
                        {

                            StaffMembersManageListFront.Add(stml.convertToStaffMemberFront(stml));
                        }                  
                    
                        foreach (StaffMemberFront stml in StaffMembersManageListFront)
                        {
                            stml.staffMembersFront = DisplayStaffMemberManage(stml);
                        }
            }
            return StaffMembersManageListFront;
        }

        #endregion
    }
}
