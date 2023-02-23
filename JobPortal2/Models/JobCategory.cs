using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal2.Models
{
    [Table("JobCategories")]
    public class JobCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobCategoryId { get; set; }


        [Required(ErrorMessage = "Cannot be Empty"), StringLength(100)]
        public string JobCategoryName { get; set; }


        [MinLength(5), MaxLength(1000)]
        public string Description { get; set; }















    }
}
