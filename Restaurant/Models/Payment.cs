using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Restaurant.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }

        [Required(ErrorMessage = "Cannot be Empty")]
        [StringLength(50)]
        public string PaymentType { get; set; }



        #region Navigation Properties to the Transaction Model - Orders

        public ICollection<Order> Orders { get; set; }

        #endregion

        #region Navigation Properties to the Transaction Model - Customer

        public ICollection<Customer> Customers { get; set; }

        #endregion

    }
}
