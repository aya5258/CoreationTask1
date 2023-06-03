
using ProductCustomer.Data.Repository;
using System.ComponentModel.DataAnnotations;

namespace ProductCustomer.Models
{
    public class Customer:IEntityBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required FullName")]
        [StringLength(100, ErrorMessage = "The FullName cannot exceed 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Required Mobile")]
        [StringLength(11, ErrorMessage = "The Mobile cannot exceed 11 characters")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Required Mobile")]
        [StringLength(250, ErrorMessage = "The address cannot exceed 250 characters")]
        public string address { get; set; }

        public virtual ICollection<Product> Products { get; set; }



    
    }
}
