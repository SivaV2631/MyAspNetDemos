using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal1.Models
{
    [Table("JobRequirementDetails")]
    public class JobRequirementDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobRequirementDetailId { get; set; }

        [Display(Name = "Job Requirement Details")]
        [Required]
        [StringLength(500)]
        public string JobRequirmentDetailName { get; set; }

        #region Navigation Properties to the Master Model - JobReuirement

        [Required]
        public int JobRequirementId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(JobRequirementDetail.JobRequirementId))]
        public JobRequirement JobRequirement { get; set; }

        #endregion

    }
}
