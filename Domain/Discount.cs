using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public enum DiscountType
    {
        Percentage, Value
    }

    //[Table("Discount")]
    public class Discount : BaseEntity
    {
        [Required]
        public string code { get; set; }

        [Required]
        public bool activationStatus { get; set; }

        [Required]
        public DiscountType type { get; set; }
        public double value { get; set; }

        public Doctor doctorCoupon { get; set; }
    }
}
