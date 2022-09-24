using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    [Table("JobStatuses")]
    public class JobStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobStatusId { get; set; }

        [Required]
        [StringLength(100)]
        public string JobStatusName { get; set; }

        #region Navigation properties to model - PostJob
        public ICollection<PostJob> PostJobs { get; set; }
        #endregion
    }
}
