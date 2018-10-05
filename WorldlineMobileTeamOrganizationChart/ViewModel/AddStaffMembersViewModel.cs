using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorldlineMobileTeamOrganizationChart.Helpers;
using WorldlineMobileTeamOrganizationChart.Model.Classes.Employees;



namespace WorldlineMobileTeamOrganizationChart.ViewModel
{
    class AddStaffMembersViewModel : BindableBaseViewModel
    {

        private string _Surname;
        private string _Name;
        private string _Mail;
        private string _Tel;
        private Fonction _GetFonction;

        public string Surname { get => _Surname; set { _Surname = value; RaisePropertyChanged(nameof(Surname)); } }
        public string Name { get => _Name; set { _Name = value; RaisePropertyChanged(nameof(Name)); }
}
        public string Mail { get => _Mail; set { _Mail = value; RaisePropertyChanged(nameof(Mail)); } }
        public string Tel { get => _Tel; set { _Tel = value; RaisePropertyChanged(nameof(Tel)); } }
        public Fonction GetFonction { get => _GetFonction; set { _GetFonction = value; RaisePropertyChanged(nameof(GetFonction)); } }


        public ICommand CommandAddStaffMember { get; set; }
        public ICommand CommandAddManager { get; set; }

        public AddStaffMembersViewModel ()
        {
            CommandAddManager = new RelayCommand(DisplayAllManager);
            CommandAddStaffMember = new RelayCommand(UpdateBdd); 
        }

        public async void UpdateBdd()
        {
            
            using (var context = new StaffMembersContext())
            {
                context.Database.EnsureCreated();
                var staffMember = new StaffMember
                {
                    SurName = this.Surname ,                    
                    Mail = this.Mail,
                    Name = this.Name ,
                    Tel = this.Tel,
                    Fonction=GetFonction,
                };
               await context.AddAsync(staffMember);
                
                var members = context.StaffMember.ToList();
                context.SaveChanges();

                
            }          
        }

        public void DisplayAllManager()
        {
            using (var context = new StaffMembersContext())
            {
                var manager = from m in context.StaffMember
                              where m.Fonction == 0
                              select m;
                manager.ToList();
                context.SaveChangesAsync();
            }
        }


    }
}
