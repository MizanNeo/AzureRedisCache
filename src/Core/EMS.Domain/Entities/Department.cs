using EMS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace EMS.Domain.Entities
{
    public class Department : AuditableEntity
    {

        public int DepartmentId { get; set; }
        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }
    }
}