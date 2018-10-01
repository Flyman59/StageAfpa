using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WorldlineMobileTeamOrganizationChart.Helpers;
using WorldlineMobileTeamOrganizationChart.View;

namespace WorldlineMobileTeamOrganizationChart.ViewModel
{
    class OrganizationChartViewModel
    {
        public ICommand CommandAddStaffMembers { get; private set; }


        public OrganizationChartViewModel()
        {
           CommandAddStaffMembers = new RelayCommand(OpenWindowsAddStaffMembers) ;
        }

       public void OpenWindowsAddStaffMembers()
        {


            AddStaffMembersView addStaffMembersView = new AddStaffMembersView();
            addStaffMembersView.Show();
            
            
        }

    }
}
