using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Bootstrap2.Models
{

    [Table("Categories")]

    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Display(Name = "Name of the Category")]
        [Required(ErrorMessage = "{0} cannot be empty ")]
        [StringLength(60, ErrorMessage = "{0} cannot have more than {1} Chatracters")]
        public string CategoryName { get; set; }

        #region Navigation Properties to the Transaction Model - Book

        public ICollection<Book> Books { get; set; }

        #endregion

        #region Navigation Properties to the Transaction Model - Grocery

        public ICollection<Grocery> Groceries { get; set; }

        #endregion

        #region Navigation Properties to the Transaction Model - Product

        public ICollection<Product> Products { get; set; }

        #endregion


    }
}
