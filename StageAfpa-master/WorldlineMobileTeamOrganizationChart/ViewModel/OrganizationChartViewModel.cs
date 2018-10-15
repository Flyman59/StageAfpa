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
        private List<StaffMember> _MembersList;
        private List<StaffMember> _ChiefManagersList;
        private StaffMemberFront _ManagerFrontId;

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
        public List<StaffMember> membersList { get => _MembersList; set { _MembersList = value; RaisePropertyChanged(nameof(membersList)); } }
        
        public List<StaffMember> ChiefManagersList { get => _ChiefManagersList; set { _ChiefManagersList = value; RaisePropertyChanged(nameof(ChiefManagersList)); } }
        #endregion


        public ICommand CommandAddStaffMembers { get; private set; }
        public StaffMemberFront ManagerFrontId { get => _ManagerFrontId; set { _ManagerFrontId = value;RaisePropertyChanged(nameof(ManagerFrontId)); } }

        public OrganizationChartViewModel()
        {

            using (var context = new StaffMembersContext())
            {
                context.Database.EnsureCreated();
            }









            #region//Filtrage des données


            using (var contextStaffMembersFrontId = new StaffMembersContext())
            {
                var chiefManagerId = from idManager in contextStaffMembersFrontId.staffMember
                                where idManager.ManagerID == 0
                                select idManager;

                ChiefManagersList = chiefManagerId.ToList();

                contextStaffMembersFrontId.SaveChanges();
            }



            using (var contextAllStaffMembers = new StaffMembersContext())
            {
                var members = contextAllStaffMembers.staffMember;
                membersList = members.ToList();
                contextAllStaffMembers.SaveChanges();
            }



            #endregion

            CommandAddStaffMembers = new RelayCommand(OpenWindowsAddStaffMembers);


        }

       public void OpenWindowsAddStaffMembers()
       {


            AddStaffMembersView addStaffMembersView = new AddStaffMembersView();
            
            addStaffMembersView.Show();
            

       }



    }
}
