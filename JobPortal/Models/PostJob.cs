using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    [Table("PostJobs")]
    public class PostJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PostJobId { get; set; }


        #region Navigation Properties for model - Company
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey(nameof(PostJob.CompanyId))]

        public Company Company { get; set; }
        #endregion


        #region Navigation Properties for model - Job
        [Required]
        public int JobId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(PostJob.JobId))]

        public Job Job { get; set; }
        #endregion

        public int RequiredPerson { get; set; }


        [StringLength(50)]
        [Required]
        public string Qualification { get; set; }


        [StringLength(100)]
        [Required]
        public string MinimumExperience { get; set; }

        public int AgeLimit { get; set; }

        public string MarriedStatus { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ShortListDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime InterviewDate { get; set; }

        #region Navigation Properties to the Master Model - JOBSTATUS

        [Required]
        public int JobStatusId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(PostJob.JobStatusId))]
        public JobStatus JobStatus { get; set; }

        #endregion

        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        public string Description { get; set; }


        //#region Navigation Properties for model - User
        //[Required]
        //public int UserId { get; set; }
        //[ForeignKey(nameof(PostJob.UserId))]

        //public UserTable UserTable { get; set; }
        //#endregion






    }
}
