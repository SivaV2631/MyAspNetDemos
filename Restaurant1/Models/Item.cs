using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Restaurant1.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemId { get; set; }

        [Display(Name ="Item Name")]
        [Required]
        public string ItemName { get; set; }


        [Required]
        public decimal ItemPrice { get; set; }

        [Required]
        public decimal ItemQuantity { get; set; }


        #region Navigation Properties to the Master Model - Category


        [Required]
        public int CategoryId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Item.CategoryId))]
        public Category Category { get; set; }

        #endregion


        #region Navigation Properties to the Transaction Model - Orders

        [Required]
        public int OrderId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Item.OrderId))]
        public Order Order { get; set; }

        #endregion
    }
}
