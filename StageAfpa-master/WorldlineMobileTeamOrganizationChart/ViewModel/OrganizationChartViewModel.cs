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
using WorldlineMobileTeamOrganizationChart.ViewModel;


namespace WorldlineMobileTeamOrganizationChart.ViewModel
{
    class OrganizationChartViewModel : BindableBaseViewModel
    {

        

        #region //propiétés        
        private List<StaffMemberFront> _ChiefManagersListFront;
        private List<StaffMember> _ChiefManagersList;
        private StaffMember _AssignedTreeView;
        


        private string _Surname;
        private string _Name;
        private string _Mail;
        private string _Tel;
        private StaffFonction _Fonction;

        public string Surname { get => _Surname; set { _Surname = value; RaisePropertyChanged(nameof(Surname)); } }
        public string Name { get => _Name; set { _Name = value; RaisePropertyChanged(nameof(Name)); } }
        public string Mail { get => _Mail; set { _Mail = value; RaisePropertyChanged(nameof(Mail)); } }
        public string Tel { get => _Tel; set { _Tel = value; RaisePropertyChanged(nameof(Tel)); } }
        public StaffFonction Fonction { get => _Fonction; set { _Fonction = value; RaisePropertyChanged(nameof(Fonction)); } }
        public List<StaffMember> ChiefManagersList { get => _ChiefManagersList; set { _ChiefManagersList = value; RaisePropertyChanged(nameof(ChiefManagersList)); } }
        public List<StaffMemberFront> ChiefManagersListFront { get => _ChiefManagersListFront; set { _ChiefManagersListFront = value; RaisePropertyChanged(nameof(ChiefManagersList)); RaisePropertyChanged(nameof(AssignedTreeView)); } }
        public StaffMember AssignedTreeView { get => _AssignedTreeView; set { _AssignedTreeView = value; RaisePropertyChanged(nameof(AssignedTreeView)); RaisePropertyChanged(nameof(ChiefManagersListFront)); } }
        

        public ICommand CommandAddStaffMembers { get; private set; }
        public ICommand CommandUpdateStaffMembers { get; private set; }
        public ICommand CommandRemoveStaffMembers { get; private set; }
        

        BddEfCoreHelper BddEfCoreHelper = new BddEfCoreHelper();

        #endregion

        public OrganizationChartViewModel()
        {
        
            #region//Filtrage des données pour la TriewView
            DisplayTreeView();
            #endregion

            #region //RelayCommand
            CommandAddStaffMembers = new RelayCommand(OpenWindowsAddStaffMembers);
            CommandUpdateStaffMembers = new RelayCommand(ModifiedStaffMember);
            CommandRemoveStaffMembers = new RelayCommand(DeleteStaffMember);
            #endregion
        }
        #region//Methodes
        public void DisplayTreeView()
        {
            
           ChiefManagersList = BddEfCoreHelper.FiltreChiefManager();
           

                ChiefManagersListFront = new List<StaffMemberFront>();
            
                foreach (StaffMember smcfm in  ChiefManagersList)
                {
                    ChiefManagersListFront.Add(smcfm.convertToStaffMemberFront(smcfm));
                }
                List<StaffMemberFront> test = new List<StaffMemberFront>();

                foreach (StaffMemberFront smcfmf in ChiefManagersListFront)
                {
                    smcfmf.staffMembersFront = DisplayStaffMemberManage(smcfmf);

                }
            
            RaisePropertyChanged(nameof(ChiefManagersListFront));
        }
        public void OpenWindowsAddStaffMembers()
        {
            AddStaffMembersView addStaffMembersView = new AddStaffMembersView();
            
            addStaffMembersView.Show();
        }

        public List<StaffMemberFront> DisplayStaffMemberManage(StaffMemberFront smcfm)
        {
            List<StaffMemberFront> StaffMembersManageListFront = new List<StaffMemberFront>();

            List<StaffMember> StaffMemberManageList = BddEfCoreHelper.FiltreManageMember(smcfm);
                        
                        foreach (StaffMember stml in StaffMemberManageList)
                        {
                            StaffMembersManageListFront.Add(stml.convertToStaffMemberFront(stml));
                        }                  
                    
                        foreach (StaffMemberFront stml in StaffMembersManageListFront)
                        {
                            stml.staffMembersFront = DisplayStaffMemberManage(stml);
                        }
                        return StaffMembersManageListFront;
        }

        public void ModifiedStaffMember()
        {
            try
            {
                BddEfCoreHelper.UpdateStaffMemberBDD(AssignedTreeView);
                DisplayTreeView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Saisie invalide", "Veuillez verifier les données saisie" + ex.Message);
            }
        }

        public void DeleteStaffMember()
        {
            BddEfCoreHelper.Delete(AssignedTreeView);
            DisplayTreeView();
        }
        #endregion
    }
}
