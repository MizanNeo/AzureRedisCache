using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities
{
    public class Country
    {
        public int CountryId { get; set; }
        [StringLength(50)]
        [Required]
        public string CountryName { get; set; }
    }
}
