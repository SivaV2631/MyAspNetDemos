using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Restaurant1.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int PaymentId { get; set; }

        [Required(ErrorMessage ="Cannot be Empty")]
        [StringLength(50)]
        public string PaymentType { get; set; }

        #region Navigation Properties to the Transaction Model - Orders

        [Required]
        public int OrderId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Payment.OrderId))]
        public Order Order { get; set; }

        #endregion


    }
}
