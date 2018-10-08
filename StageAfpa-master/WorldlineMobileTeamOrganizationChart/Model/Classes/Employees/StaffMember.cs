using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace WorldlineMobileTeamOrganizationChart.Model.Classes.Employees
{
    public class StaffMember
    {
        [Key] 
        public int ID { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }
        [Required]
        public Fonction Fonction { get; set; }
    }
}
