using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    //[Table("Specialization")]
    public class Specialization : BaseEntity
    {
        [Required]
        public string name { get; set; }
        public List<Doctor> doctors { get; set; }
    }
}
