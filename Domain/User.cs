using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain
{
    public enum Gender
    {
        Male, Female
    }

    [NotMapped]
    public class User : BaseEntity
    {
        public string? image { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "First name cannot exceed 30 characters.")]
        public string firstName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "First name cannot exceed 30 characters.")]
        public string lastName { get; set; }
        public Gender gender { get; set; }
        public string DOB { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format.")]
        public string email { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Passowrds needs to be longer than 5 characters.")]
        public string password { get; set; }

    }
}
