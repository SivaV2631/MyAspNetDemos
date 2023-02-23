using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal1.Models
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


        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; }


        public int Vacancies { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostCreatedAt { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastDate { get; set; }



        [StringLength(50)]
        [Required]
        public string Qualification { get; set; }

        [DataType(DataType.Currency)]
        public int MinSalary { get; set; }

        [DataType(DataType.Currency)]
        public int MaxSalary { get; set; }

        [StringLength(100)]
        public string Location { get; set; }



        #region Navigation Properties to the Master Model - JOBREQUIREMENT

        [Required]
        public int JoRequirementId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(PostJob.JoRequirementId))]
        public JobRequirement JobRequirement { get; set; }

        #endregion

        #region Navigation Properties to the Master Model - JOBSTATUS

        [Required]
        public int JobStatusId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(PostJob.JobStatusId))]
        public JobStatus JobStatus { get; set; }

        #endregion

        [DataType(DataType.MultilineText)]
        [StringLength(500)]
        public string JobDescription { get; set; }


        #region Navigation Properties for model - Jobnature
        [Required]
        public int JobNatureId { get; set; }
        [ForeignKey(nameof(PostJob.JobNatureId))]

        public JobNature JobNature { get; set; }
        #endregion


        //#region Navigation Properties for model - User
        //[Required]
        //public int UserId { get; set; }
        //[ForeignKey(nameof(PostJob.UserId))]

        //public UserTable UserTable { get; set; }
        //#endregion






    }
}
