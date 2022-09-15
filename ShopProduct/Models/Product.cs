using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using MyAspDemos.Models;

namespace ShopProduct.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }


        [Required]
        [Display(Name ="Name of product ")]
        [StringLength(100)]
        public string ProductName { get; set; }

        #region Navigation Properties to the Master Model - Category


        [Required]
        public int CategoryId { get; set; }


        [ForeignKey(nameof(Product.CategoryId))]
        public Category Category { get; set; }


        #endregion

    }
}
