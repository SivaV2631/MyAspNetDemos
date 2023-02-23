using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal1.Models
{
    [Table("Skills")]
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }

        [Required]
        [StringLength(500)]
        public string SkillName { get; set; }

        #region Navigation Properties for model - Employee

        [Required]
        public int EmployeeId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Skill.EmployeeId))]

        public Employee Employee { get; set; }
        #endregion
    }
}
