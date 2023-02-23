using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal1.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }


        [Display(Name = "Country")]
        [Required, StringLength(50)]
        public string CountryName { get; set; }


        [Display(Name = "Country Code")]
        [DataType(DataType.PostalCode)]
        public int CountryCode { get; set; }


        #region
        public ICollection<Employee> Employees { get; set; }
        #endregion

        #region
        public ICollection<WorkExperience> WorkExperiences { get; set; }
        #endregion
    }
}
