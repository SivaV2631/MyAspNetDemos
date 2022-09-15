using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant1.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }


        [Display(Name ="Name of Category")]
        [Required(ErrorMessage ="{0} cannot be empty")]
        public string CategoryName { get; set; }


        #region Navigation Properties to the transaction model - Item

        public ICollection<Item> Items { get; set; }

        #endregion
    }
}
