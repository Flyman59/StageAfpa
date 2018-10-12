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
        private List<StaffMember> _ManagerList;
        private List<StaffMemberFront> _ChiefManagersList;

        private string _Surname;
        private string _Name;
        private string _Mail;
        private string _Tel;



        public string Surname { get => _Surname; set { _Surname = value; RaisePropertyChanged(nameof(Surname)); } }
        public string Name { get => _Name; set { _Name = value; RaisePropertyChanged(nameof(Name)); } }
        public string Mail { get => _Mail; set { _Mail = value; RaisePropertyChanged(nameof(Mail)); } }
        public string Tel { get => _Tel; set { _Tel = value; RaisePropertyChanged(nameof(Tel)); } }
        public List<StaffMember> managerList { get => _ManagerList; set { _ManagerList = value; RaisePropertyChanged(nameof(managerList)); } }
        public List<StaffMemberFront> ChiefManagersList { get => _ChiefManagersList; set { _ChiefManagersList = value; RaisePropertyChanged(nameof(ChiefManagersList)); } }
        #endregion


        public ICommand CommandAddStaffMembers { get; private set; }
        

        public OrganizationChartViewModel()
        {
            managerList = new List<StaffMember>();
            ChiefManagersList = new List<StaffMemberFront>();
            ChiefManagersList.Cast<StaffMember>();
            

            using (var context = new StaffMembersContext())
            {
                context.Database.EnsureCreated();
            }

            
           

            
            

            #region//Filtrage des données
            using (var contextManager = new StaffMembersContext())
            {
                var ChiefManagersList = from fontionManager in contextManager.StaffMember
                              where fontionManager.Fonction == StaffFonction.Manager
                              select fontionManager;

                managerList = ChiefManagersList.ToList();

                contextManager.SaveChanges();
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
