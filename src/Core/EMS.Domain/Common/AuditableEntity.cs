using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EMS.Domain.Common
{
    public class AuditableEntity
    {
        [JsonIgnore]
        [StringLength(50)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [StringLength(50)]
        [JsonIgnore]
        public string? LastModifiedBy { get; set;}
        [Column(TypeName ="datetime")]
        [JsonIgnore]
        public DateTime? LastModifiedDate { get; set;}
    }
}
