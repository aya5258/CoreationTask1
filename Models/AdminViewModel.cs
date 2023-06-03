using System.ComponentModel.DataAnnotations;

namespace ProductCustomer.Models
{
    public class AdminViewModel
    {
        [Required]
        public string Role { get; set; }
    }
}
