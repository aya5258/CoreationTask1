using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProductCustomer.Data.Repository;

namespace ProductCustomer.Models
{
    public class Product:IEntityBase
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }


        [ForeignKey("Customer")]
        public int? Cutomer_id { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
