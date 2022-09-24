using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId { get; set; }


        [Display(Name="Company Name")]
        [Required(ErrorMessage ="Company Name Cannot be Empty")]
        public string CompanyName { get; set; }


        [Display(Name = "Contact No")]
        [Required(ErrorMessage ="Contact No is required")]
        [RegularExpression(@"^[1-9]+$",ErrorMessage ="Cannot have negative values")]
        [DataType(DataType.PhoneNumber)]
        public int ContactNo { get; set; }



        [Required(ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",ErrorMessage ="Email is InValid")]
        public string EmailAddress { get; set; }



        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }


        [MinLength(10),MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        #region Navigation Properties for model - User
        [Required]
        public int UserId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Company.UserId))]
        public UserTable UserTable { get; set; }
        #endregion


        #region Navigation properties to model - Event

        public ICollection<EventTable> EventTables { get; set; }
        #endregion

    }
}
