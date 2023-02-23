using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal1.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }


        [Required(ErrorMessage = "Employee name Cannot be empty")]
        [StringLength(50)]
        public string EmployeeName { get; set; }


        [Required(ErrorMessage = "DOB Cannot be empty")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }


        [Required]
        public int EmployeeAge { get; set; }


        [StringLength(50)]
        public string FatherName { get; set; }



        [Required(ErrorMessage = "Email Cannot be Empty"), StringLength(50)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is InValid")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required, StringLength(50)]
        public string Gender { get; set; }


        [Required]
        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }



        [Required(ErrorMessage = "Qualification cannot be Empty")]
        public string Qualification { get; set; }


        [Required]
        [DataType(DataType.Text)]
        public string PermanentAddress { get; set; }


        [DataType(DataType.Upload)]
        public string AttachCV { get; set; }


        public string JobReferences { get; set; }


        [DataType(DataType.MultilineText)]
        [MinLength(50), MaxLength(500)]
        public string Description { get; set; }







        #region Navigation Properties to the Master Model - JobCategory

        [Required]
        public int JobCategoryId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Employee.JobCategoryId))]
        public JobCategory JobCategory { get; set; }

        #endregion


        #region Navigation Properties to the Master Model - COUNTRY

        [Required]
        public int CountryId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Employee.CountryId))]
        public Country Country { get; set; }

        #endregion


        #region Navigation properties from model - Certificate

        public ICollection<Certificate> Certificates { get; set; }
        #endregion


        #region Navigation properties from model - Language

        public ICollection<Language> Languages { get; set; }
        #endregion


        #region Navigation properties from model - JobApply

        public ICollection<JobApply> JobApplies { get; set; }
        #endregion


        #region Navigation properties from model - EDUCATION

        public ICollection<Education> Educations { get; set; }
        #endregion


        #region Navigation properties from model - SKILL

        public ICollection<Skill> Skills { get; set; }
        #endregion


        #region Navigation properties from model - WORK EXPERIENCE

        public ICollection<WorkExperience> WorkExperiences { get; set; }
        #endregion

    }
}
