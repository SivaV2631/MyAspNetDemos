using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal1.Models
{
    [Table("Certificates")]
    public class Certificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CertificateId { get; set; }

        [Display(Name = "Certificate Name")]
        public string CertificateName { get; set; }

        [Display(Name = "Certificate Authority")]
        public string CertificateAuthority { get; set; }

        [Display(Name = "Certification Level")]
        public string LevelCertification { get; set; }

        [Display(Name = "From Year")]
        [DataType(DataType.Date)]
        public DateTime FromYear { get; set; }


        #region Navigation Properties for model - Employee

        [Required]
        public int EmployeeId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(Certificate.EmployeeId))]

        public Employee Employee { get; set; }
        #endregion
    }
}
