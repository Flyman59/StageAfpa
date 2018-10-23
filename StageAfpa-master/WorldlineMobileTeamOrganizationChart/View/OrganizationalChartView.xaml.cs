using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WorldlineMobileTeamOrganizationChart.Model.Classes.Employees;
using WorldlineMobileTeamOrganizationChart.ViewModel;

namespace WorldlineMobileTeamOrganizationChart.View
{
    /// <summary>
    /// Logique d'interaction pour OrganizationalChartView.xaml
    /// </summary>
    public partial class OrganizationalChartView : Window
    {
        public OrganizationalChartView()
        {
            InitializeComponent();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;
           
            if (element != null)
            {
                var staffMemberFront = element.DataContext as StaffMemberFront;
                if (staffMemberFront != null)
                {
                   (DataContext as OrganizationChartViewModel).AssignedTreeView = StaffMemberFront.convertToStaffMember(staffMemberFront);                   
                };
            }
        }
    }
}
