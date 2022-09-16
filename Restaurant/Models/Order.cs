using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Restaurant.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Display(Name = "Order Type")]
        [Required]
        [StringLength(50)]
        public string OrderType { get; set; }


        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal OrderAmount { get; set; }

        [Display(Name = "Terms & Conditions")]
        [Required]
        public bool TermsandConditions { get; set; }



        #region Navigation Properties to Item

        [Required]
        public int ItemId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Order.ItemId))]
        public Item Item { get; set; }

        #endregion


        #region Navigation Properties to - Payments


        [Required]
        public int PaymentId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Order.PaymentId))]
        public Payment Payment { get; set; }



        #endregion


        #region Navigation Properties to the Master Model - Customer


        [Required]
        public int CustomerId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Order.CustomerId))]
        public Customer Customer { get; set; }

        #endregion

        #region Navigation Properties to the Master Model - Table


        [Required]
        public int TableId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Order.TableId))]
        public Table Table { get; set; }

        #endregion


    }
}
