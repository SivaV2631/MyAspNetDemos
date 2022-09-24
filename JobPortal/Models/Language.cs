using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    [Table("Languages")]
    public class Language
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageId { get; set; }

        [StringLength(50)]
        public string LanguageName { get; set; }
        public string Proficiency { get; set; }

        #region Navigation Properties for model - Employee

        [Required]
        public int EmployeeId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Language.EmployeeId))]

        public Employee Employee { get; set; }
        #endregion
    }
}
