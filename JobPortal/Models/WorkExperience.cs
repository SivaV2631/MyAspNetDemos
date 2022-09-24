using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    [Table("WorkExperiences")]
    public class WorkExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkExperienceId { get; set; }

        
        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        #region Navigation Properties to the Master Model - COUNTRY

        [Required]
        public int CountryId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(WorkExperience.CountryId))]
        public Country Country { get; set; }

        #endregion


        [DataType(DataType.Date)]
        public DateTime FromYear { get; set; }


        [DataType(DataType.Date)]
        public DateTime ToYear { get; set; }

        //#region Navigation Properties for model - Employee

        //[Required]
        //public int EmployeeId { get; set; }

        //[JsonIgnore]
        //[ForeignKey(nameof(WorkExperience.EmployeeId))]

        //public Employee Employee { get; set; }
        //#endregion
    }
}
