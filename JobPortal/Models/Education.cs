using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    [Table("Educations")]
    public class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EducationId { get; set; }

        [Display(Name ="Institute Name")]

        [Required(ErrorMessage ="{0} Cannot be Empty")]
        [StringLength(100,ErrorMessage ="{0} Cannot have more than {1} Characters")]
        public string InstituteName { get; set; }


        [Display(Name ="Branch")]
        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [StringLength(100, ErrorMessage = "{0} Cannot have more than {1} Characters")]
        public string TitleOfEducation { get; set; }

        [Required(ErrorMessage = "{0} Cannot be Empty")]
        [StringLength(100, ErrorMessage = "{0} Cannot have more than {1} Characters")]
        public string Degree { get; set; }


        [Display(Name ="From Year")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime FromYear { get; set; }

        [Display(Name = "To Year")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime ToYear { get; set; }

        public string City { get; set; }

        #region Navigation Properties to the Master Model - COUNTRY

        [Required]
        public int CountryId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Education.CountryId))]
        public Country Country { get; set; }

        #endregion

        //#region Navigation Properties for model - Employee

        //[Required]
        //public int EmployeeId { get; set; }

        //[JsonIgnore]
        //[ForeignKey(nameof(Education.EmployeeId))]

        //public Employee Employee { get; set; }
        //#endregion




    }
}
