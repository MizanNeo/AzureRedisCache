using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities
{
    public class Salary
    {
        public required int EmployeeId {  get; set; }
        public Employee? Employee { get; set; }
        public double Basic {  get; set; }
        public double SpecialAllowance { get; set; }
        public double HouseAllowance { get; set; }
        public double MedicalAllowance { get; set; }
    }
}
