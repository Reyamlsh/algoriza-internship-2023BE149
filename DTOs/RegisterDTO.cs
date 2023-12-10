using Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format.")]
        public string email { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "First name cannot exceed 30 characters.")]
        public string firstName { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "First name cannot exceed 30 characters.")]
        public string lastName { get; set; }

        [Required]
        public string phoneNumber { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Passowrds needs to be longer than 5 characters.")]
        public string password { get; set; }
        public Gender gender { get; set; }
        public string DOB { get; set; }
        public string? image { get; set; }

        


     
    }
}
