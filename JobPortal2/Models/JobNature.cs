using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal2.Models
{
    [Table("JobNatures")]
    public class JobNature
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobNatureId { get; set; }

        [Required]
        [StringLength(50)]
        public string JobNatureName { get; set; }


        #region Navigation properties from model - Post Job

        public ICollection<PostJob> PostJobs { get; set; }
        #endregion


    }
}
