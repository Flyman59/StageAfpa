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
        private List<StaffMemberFront> _StaffMembersManageListFront;
        private List<StaffMember> _ChiefManagersList;
        private List<StaffMember> _StaffMemberManageList;
        //private List<StaffMemberFront> _ManagersListFront;
       // private List<StaffMember> _StaffMembersList;

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
        public List<StaffMemberFront> StaffMembersManageListFront { get => _StaffMembersManageListFront; set { _StaffMembersManageListFront = value; RaisePropertyChanged(nameof(StaffMembersManageListFront)); } }
        //public List<StaffMember> StaffMembersList { get => _StaffMembersList; set { _StaffMembersList = value;RaisePropertyChanged(nameof(StaffMembersList)); } }
        public List<StaffMember> StaffMemberManageList { get => _StaffMemberManageList; set { _StaffMemberManageList = value;RaisePropertyChanged(nameof(StaffMemberManageList)); } }
        //public List<StaffMemberFront> ManagersListFront { get => _ManagersListFront; set { _ManagersListFront = value;RaisePropertyChanged(nameof(ManagersListFront)); } }

        public int compteurStaffMember = -1;

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

                foreach (StaffMemberFront smcfmf in ChiefManagersListFront)
                {
                    smcfmf.staffMembersFront = DisplayStaffMemberManage(smcfmf);
                }





                    contextChiefManager.SaveChanges();
            }


            //using (var contextAllStaffMember = new StaffMembersContext())
            //{

            //    var manageMembers = from membersmanageList in contextAllStaffMember.staffMember
            //                        where membersmanageList.ManagerID==ChiefManagersList
            //                        select membersmanageList;
            //    ManagersList = manageMembers.ToList();
            //    ManagersList = new List<StaffMember>();


            //    foreach (StaffMember sm in ManagersList)
            //    {
            //        ChiefManagersListFront.Add(sm.convertToStaffMemberFront(sm));
            //    }

            //    contextAllStaffMember.SaveChanges();
            //}






            #endregion

            CommandAddStaffMembers = new RelayCommand(OpenWindowsAddStaffMembers);


        }

       public void OpenWindowsAddStaffMembers()
       {


            AddStaffMembersView addStaffMembersView = new AddStaffMembersView();
            
            addStaffMembersView.Show();
            

       }

        public List<StaffMemberFront> DisplayStaffMemberManage(StaffMemberFront smcfm)
        {
            

            using (var contextStaffMemberManage = new StaffMembersContext())
            {
                var manageMembers = from membersmanageList in contextStaffMemberManage.staffMember
                                    where membersmanageList.ManagerID == smcfm.ManagerID
                                    select membersmanageList;
                StaffMemberManageList = manageMembers.ToList();
                StaffMembersManageListFront = new List<StaffMemberFront>();
                foreach(StaffMember stml in StaffMemberManageList)
                {
                    StaffMembersManageListFront.Add(stml.convertToStaffMemberFront(stml));

                    
                }
                contextStaffMemberManage.SaveChanges();
                while(compteurStaffMember<StaffMembersManageListFront.Count  )
                {
                    compteurStaffMember++;
                    DisplayStaffMemberManage(smcfm);
                }

                //do
                //{
                    
                //    compteurStaffMember++;
                //} while (compteurStaffMember < StaffMemberManageList.Count)
                //{
                //    DisplayStaffMemberManage(smcfm);
                //}

                
                

            }
            
            return StaffMembersManageListFront; 
        }

        //public void getStaffMembersNotChiefManager()
        //{
        //    using (var contextAllStaffMember = new StaffMembersContext())
        //    {
        //        var allMembers = from membersList in contextAllStaffMember.staffMember
        //                         where membersList.ManagerID != 0
        //                         select membersList;
        //        StaffMembersList = allMembers.ToList();

        //        foreach (StaffMember allMembersList in StaffMembersList)
        //        {
        //            ChiefManagersListFront.Add(allMembersList.convertToStaffMemberFront(allMembersList));
        //        }
        //    }
        //}
    }
}
