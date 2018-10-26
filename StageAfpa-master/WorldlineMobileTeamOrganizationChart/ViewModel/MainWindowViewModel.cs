using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WorldlineMobileTeamOrganizationChart.Client;
using WorldlineMobileTeamOrganizationChart.Helpers;
using WorldlineMobileTeamOrganizationChart.Model.Classes.Employees;
using WorldlineMobileTeamOrganizationChart.View;

namespace WorldlineMobileTeamOrganizationChart.ViewModel
{
    class MainWindowViewModel : BindableBaseViewModel
    {
        

        private string _UserMdp;
        private string _UserLogin;
        private string _VerifLogAndPass;

        


        

        List<UserAccount> data;
        

        

        public ICommand CommandConnexion { get; private set; }  

        public string UserLogin { get => _UserLogin; set { _UserLogin = value;RaisePropertyChanged(UserLogin); } }

        public string UserMdp { get => _UserMdp; set { _UserMdp = value;RaisePropertyChanged(UserMdp); } }

        public string VerifLogAndPass { get => _VerifLogAndPass; set { _VerifLogAndPass = value;RaisePropertyChanged(VerifLogAndPass); } }

        public BddEfCoreHelper usingBdd { get; set; }

        

        public MainWindowViewModel()
        {
            CommandConnexion = new RelayCommand(GetInfoCo);
        }

        
        

        public async void GetInfoCo()
        {
            try {
                data = await ClientBase.GetAccountPageAsync();

                bool found = false;

                foreach (UserAccount userAccount in data)
                {
                    if (userAccount.login == UserLogin)
                    {
                        VerifLogAndPass = "Login correct";

                        found = true;
                        if (userAccount.mdp == UserMdp)
                        {
                            VerifLogAndPass = "login et mot de passe correct";
                            OrganizationalChartView organizationalChartView = new OrganizationalChartView();
                            organizationalChartView.Show();

                            Application.Current.MainWindow.Close();

                        }
                        else
                        {

                            VerifLogAndPass = "Mot de passe incorrect";
                        }


                    }

                }

                if (!found)
                {
                    VerifLogAndPass = "Login incorrect";
                }
            }catch (Exception ex)
            {
                MessageBox.Show("Connection serveur impossible." + ex.Message);
            }
            

        }



    }
}
