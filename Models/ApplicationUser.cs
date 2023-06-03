using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProductCustomer.Models
{
    public class ApplicationUser:IdentityUser
    {



        [Display(Name = "First Name")]
        public string firstname { get; set; }


        [Display(Name = "Last Name")]
        public string lastName { get; set; }

    }
}
