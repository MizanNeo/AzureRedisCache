using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities
{
    public class State
    {
        public int StateId { get; set; }
        [StringLength(50)]
        [Required]
        public string StateName { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
