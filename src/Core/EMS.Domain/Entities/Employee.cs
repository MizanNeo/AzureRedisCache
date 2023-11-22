using EMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public int EmployeeId { get; set; }
        [StringLength(50)]
        public required string EmployeeName { get; set; }

        [StringLength(100)]
        public required string Email { get; set; }

        [StringLength(15)]
        public required string Mobile { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        [Required]
        public char Gender { get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }
        public int? StateId { get; set; }
        public State? State { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime JoinDate { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        [StringLength(10)]
        public required string Pan { get; set; }
        public int EmployeeTypeId { get; set; }
        [StringLength(20)]
        public string? PassportNumber { get; set; }
        [StringLength(100)]
        public string? ProfileImage { get; set; }
        [Column(TypeName = "numeric(10,2)")]
        public double Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
