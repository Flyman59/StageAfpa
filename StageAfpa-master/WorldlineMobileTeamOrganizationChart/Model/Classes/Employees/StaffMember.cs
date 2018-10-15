using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldlineMobileTeamOrganizationChart.Model.Classes.Employees
{

    public class StaffMember
    {


        public int ID { get; set; }
        //[Required]
        //[DataType(DataType.EmailAddress)]
        public string Mail { get; set; }
        //[Required]
        public string SurName { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required]
        [DataType(DataType.PhoneNumber)]
        public string Tel { get; set; }
        //[Required]
        //[EnumDataType(typeof(StaffFonction))]
        public StaffFonction Fonction { get; set; }
        public int? ManagerID { get; set; }
        public List<StaffMember> staffMembers { get; set; }
    }
}
