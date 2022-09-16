using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Restaurant.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Display(Name = "Item Name")]
        [Required]
        public string ItemName { get; set; }

        [Display(Name = "Price for item")]
        [Required]
        public decimal ItemPrice { get; set; }

        [Display(Name = "Item Quantity")]
        [Required]
        public decimal ItemQuantity { get; set; }

        [Display(Name = "Total Amount")]
        [Required]
        public decimal TotalAmount { get; set; }



        #region Navigation Properties to the Master Model - Category


        [Required]
        public int CategoryId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Item.CategoryId))]
        public Category Category { get; set; }

        #endregion


        #region Navigation Properties to the Transaction Model - Orders

        public ICollection<Order> Orders { get; set; }
        #endregion
    }
}
