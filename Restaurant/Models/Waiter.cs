using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    [Table("Waiters")]
    public class Waiter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WaiterId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty")]
        public string WaiterName { get; set; }


        #region Navigation Properties to the transaction model - Orders

        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}