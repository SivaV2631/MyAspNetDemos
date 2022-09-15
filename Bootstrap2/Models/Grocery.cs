using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Bootstrap2.Models
{
    [Table("Groceries")]
    public class Grocery
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroceryId { get; set; }

        [Display(Name = "Grocery Name")]
        [Required]
        [StringLength(100)]
        public string GroceryName { get; set; }


        [Required]
        [DefaultValue(1)]
        public int NumberOfItems { get; set; } = 1;

        [Required]
         public decimal GroceryPrice { get; set; }



        #region Navigation Properties to the Master Model - Category


        [Required]
        public int CategoryId { get; set; }

        //NOTE: To ensure that all nested objects are not serialized, add the JsonIgnore Attribute
        [System.Text.Json.Serialization.JsonIgnore]         // DO NOT USE:  [Newtonsoft.Json.JsonIgnore]
        [ForeignKey(nameof(Book.CategoryId))]
        public Category Category { get; set; }


        #endregion


    }
}
