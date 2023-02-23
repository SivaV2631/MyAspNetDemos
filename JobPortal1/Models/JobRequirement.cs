using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal1.Models
{
    [Table("JobRequirements")]
    public class JobRequirement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobRequirementId { get; set; }

        [Required]
        [StringLength(100)]
        public string JobRequirementTitle { get; set; }

        #region Navigation properties from model - WORK EXPERIENCE

        public ICollection<JobRequirement> JobRequirements { get; set; }
        #endregion



        #region Navigation properties from model - WORK EXPERIENCE

        public ICollection<JobRequirementDetail> JobRequirementDetails { get; set; }
        #endregion



    }
}
