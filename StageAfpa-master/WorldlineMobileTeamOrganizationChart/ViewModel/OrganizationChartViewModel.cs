using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private List<StaffMember> _ProjectManagerList;
        private List<StaffMember> _DeveloperList;

        private string _Surname;
        private string _Name;
        private string _Mail;
        private string _Tel;



        public string Surname { get => _Surname; set { _Surname = value; RaisePropertyChanged(nameof(Surname)); } }
        public string Name { get => _Name; set { _Name = value; RaisePropertyChanged(nameof(Name)); } }
        public string Mail { get => _Mail; set { _Mail = value; RaisePropertyChanged(nameof(Mail)); } }
        public string Tel { get => _Tel; set { _Tel = value; RaisePropertyChanged(nameof(Tel)); } }
        public List<StaffMember> managerList { get => _ManagerList; set { _ManagerList = value; RaisePropertyChanged(nameof(managerList)); } }
        public List<StaffMember> projectManagerList { get => _ProjectManagerList; set { _ProjectManagerList = value; RaisePropertyChanged(nameof(projectManagerList)); } }
        public List<StaffMember> developerList { get => _DeveloperList; set { _DeveloperList = value; RaisePropertyChanged(nameof(developerList)); } }

        public ICommand CommandAddStaffMembers { get; private set; }
        #endregion

        public OrganizationChartViewModel()
        {






            #region//Filtrage des données
            using (var contextManager = new StaffMembersContext())
            {
                var manager = from fontionManager in contextManager.StaffMember
                              where fontionManager.Fonction == Fonction.Manager
                              select fontionManager;

                managerList = manager.ToList();

                contextManager.SaveChanges();
            }

            using (var contextProjectManager = new StaffMembersContext())
            {
                var projectManager = from fonctionProjectManager in contextProjectManager.StaffMember
                                     where fonctionProjectManager.Fonction == Fonction.ChefDeProjet
                                     select fonctionProjectManager;
                projectManagerList = projectManager.ToList();


            }

            using (var contextDeveloper = new StaffMembersContext())
            {
                var developer = from fonctionDeveloper in contextDeveloper.StaffMember
                                where fonctionDeveloper.Fonction == Fonction.ChefDeProjet
                                select fonctionDeveloper;
                developerList = developer.ToList();
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
