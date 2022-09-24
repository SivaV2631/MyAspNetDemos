using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    [Table("JobApplies")]
    public class JobApply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobApplyId { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime JobApplyDateTime { get; set; }



        [DataType(DataType.DateTime)]
        public DateTime JobApplyStatusUpdateDate { get; set; }

        [StringLength(200)]
        public string JobApplyStatusUpdate { get; set; }



        #region Navigation Properties for model - JobApplyStatus

        [Required]
        public int JobApplyStatusId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(JobApply.JobApplyStatusId))]

        public JobApplyStatus JobApplyStatus { get; set; }
        #endregion


        #region Navigation Properties for model - Employee

        [Required]
        public int EmployeeId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(JobApply.EmployeeId))]

        public Employee Employee { get; set; }
        #endregion

    }
}
