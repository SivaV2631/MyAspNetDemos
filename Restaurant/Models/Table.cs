using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    [Table("Tables")]
    public class Table
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TableId { get; set; }


        
        [Required(ErrorMessage = "{0} cannot be empty")]
        public int TableNumber { get; set; }


        #region Navigation Properties to the transaction model - Orders

        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}