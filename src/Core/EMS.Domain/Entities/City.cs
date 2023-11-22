using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities
{
    public class City
    {
        public int CityId { get; set; }
        [StringLength(50)]
        [Required]
        public string CityName { get; set; }
        [Required]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
