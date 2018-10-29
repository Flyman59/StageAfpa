using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorldlineMobileTeamOrganizationChart.Helpers;
using WorldlineMobileTeamOrganizationChart.Model.Classes.Employees;
using WorldlineMobileTeamOrganizationChart.View;



namespace WorldlineMobileTeamOrganizationChart.ViewModel
{
    class AddStaffMembersViewModel : BindableBaseViewModel
    {
        #region propriétés     
        private string _Surname;
        private string _Name;
        private string _Mail;
        private string _Tel;
        private StaffMember _ManagerId;
        private StaffFonction _Fonction;

        private List<StaffMember> _ManagersList;
                
        public string Surname { get => _Surname; set { _Surname = value; RaisePropertyChanged(nameof(Surname)); } }
        public string Name { get => _Name; set { _Name = value; RaisePropertyChanged(nameof(Name)); }}
        public string Mail { get => _Mail; set { _Mail = value; RaisePropertyChanged(nameof(Mail)); } }
        public string Tel { get => _Tel; set { _Tel = value; RaisePropertyChanged(nameof(Tel)); } }

        public List<StaffMember> ManagersList { get => _ManagersList; set { _ManagersList = value; RaisePropertyChanged(nameof(ManagersList)); } }
        
        public StaffMember AssignedManager { get => _ManagerId; set { _ManagerId = value; RaisePropertyChanged(nameof(AssignedManager)); } }

        public StaffFonction Fonction { get => _Fonction; set { _Fonction = value; RaisePropertyChanged(nameof(Fonction)); } }
        public ICommand CommandAddStaffMember { get; set; }
        public ICommand CommandAddManager { get; set; }
        public ICommand CommandBack { get; set; }
        #endregion

        #region//Objet BDD
        BddEfCoreHelper BddEfCoreHelper = new BddEfCoreHelper();
        #endregion

        #region//Constructeur
        public AddStaffMembersViewModel ()
        {
            CommandBack = new RelayCommand(Retour);
            CommandAddStaffMember = new RelayCommand(UpdateBdd);
            DisplayManager();   
        }
        #endregion

        #region//Methodes
        public void DisplayManager()
        {
          ManagersList =  BddEfCoreHelper.DisplayBddManager();
        }

        public void Retour()
        {

            // Instanciation de la fenetre principale
            OrganizationalChartView organizationalChartView = new OrganizationalChartView();
            organizationalChartView.Show();
            // Ferme la premiere fenetre (celle de derriere)
            App.Current.Windows[0].Close();
        }

        public void UpdateBdd()
        {
            try {                
                    var staffMember = new StaffMember
                    {
                        SurName = this.Surname,
                        Mail = this.Mail,
                        Name = this.Name,
                        Tel = this.Tel,
                        Fonction = Fonction,
                        ManagerID = AssignedManager != null ? AssignedManager.ID : 0
                    };

                BddEfCoreHelper.AddStaffMemberBdd(staffMember);

                DisplayManager();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Saisie invalide", "Veuillez verifier les données saisie"  +  ex.Message);
            }           
        }
        #endregion
    }
}
