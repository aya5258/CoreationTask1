using System.ComponentModel.DataAnnotations;

namespace ProductCustomer.Models
{
    public class LoginViewModel
    {
        //    [Required]
        //    [EmailAddress]
        //    public string Email { get; set; }


        [Required]
        public string username { get; set; }



        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
