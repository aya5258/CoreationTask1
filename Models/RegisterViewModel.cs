using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProductCustomer.Models
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name = "User Name")]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The firstname cannot exceed 100 characters")]
        public string firstname { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The lastname cannot exceed 100 characters")]

        public string lastname { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, and one number.")]
        public string Password { get; set; }


        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone")]

        public string phone { get; set; }

        [Required]
        [Display(Name = "City")]
        public string city { get; set; }


    }
}
