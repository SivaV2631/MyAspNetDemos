using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal2.Models
{
    [Table("ApplyJobs")]
    public class ApplyJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ApplyJobId { get; set; }

        [Required]
        [StringLength(100)]
        public string ApplicantName { get; set; }




        [NotMapped]
        [DataType(DataType.ImageUrl)]
        public IFormFile Photo { get; set; }


        [NotMapped]
        [DataType(DataType.Upload)]
        public IFormFile AttachCV { get; set; }



        [Required(ErrorMessage = "{0} is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid Phone Number")]
        [MinLength(10, ErrorMessage = "Invalid Phone Number"), MaxLength(10, ErrorMessage = "Invalid Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public int ContactNo { get; set; }



        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is InValid")]
        public string Email { get; set; }


        [DataType(DataType.Date)]
        public DateTime AppliedAt { get; set; }

        #region Navigation Properties to the Master Model - PostJob
        [Required]
        public int PostJobId { get; set; }


        [JsonIgnore]
        [ForeignKey(nameof(ApplyJob.PostJobId))]
        public PostJob PostJob { get; set; }

        #endregion


    }
}
