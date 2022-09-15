using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;


namespace Restaurant1.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Display(Name ="Order Type")]
        [Required]
        [StringLength(50)]
        public string OrderName { get; set; }

        [Required]
        public bool OrderStatus { get; set; }

        




        #region Navigation Properties to Item

        [JsonIgnore]
        public ICollection<Item> Items { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Order.CustomerId))]

        #endregion

        #region Navigation Properties to - Payments

        
        public ICollection<Payment> Payments { get; set; }

        #endregion


        #region Navigation Properties to the Master Model - Customer


        [Required]
        public int CustomerId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Order.CustomerId))]
        public Customer Customer { get; set; }

        #endregion


    }
}
