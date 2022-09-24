using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    [Table("Jobs")]
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        [Required]
        [StringLength(200)]
        public string JobTitle { get; set; }


        [Required,StringLength(200)]
        public string JobRequirements { get; set; }

        [Required]
        [MinLength(5),MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string JobDetails { get; set; }



        #region Navigation Properties For Model - JobCategory
        [Required]
        public int JobCategoryId { get; set; }
        [JsonIgnore]

        [ForeignKey(nameof(Job.JobCategoryId))]
        public JobCategory JobCategory { get; set; }
        #endregion

    }
}
