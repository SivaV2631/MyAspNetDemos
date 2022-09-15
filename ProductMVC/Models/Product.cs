using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ProductMVC.Models
{
    [Table("Products")]
    public class Product
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty ")]
        [StringLength(60, ErrorMessage = "{0} cannot have more than {1} Characters")]
        public string ProductName { get; set; }

       
    }
}






