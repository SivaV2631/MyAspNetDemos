using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal1.Models
{
    [Table("JobApplyStatuses")]
    public class JobApplyStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobApplyStatusId { get; set; }

        [Required]
        [StringLength(100)]
        public string JobApplyStatusName { get; set; }

        #region Navigation properties for model - JobApply
        public ICollection<JobApply> JobApplies { get; set; }
        #endregion


    }
}
