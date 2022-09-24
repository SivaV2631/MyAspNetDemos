using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal.Models
{
    [Table("EventTables")]
    public class EventTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventTableId { get; set; }


        [Required(ErrorMessage ="Cannot be empty")]
        public string EventTitle { get; set; }


        [Required,DataType(DataType.DateTime)]
        public DateTime EventDate { get; set; }


        #region Navigation Properties to the Master Model - Company

        [Required]
        public int CompanyId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(EventTable.CompanyId))]
        public Company Company { get; set; }

        #endregion

        [Required,StringLength(100)]
        public string Location { get; set; }



        [Required, DataType(DataType.Date)]
        public DateTime StartDate { get; set; }



        [Required, DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [Required,StringLength(200)]
        [DataType(DataType.Text)]
        public string EventContactDetails { get; set; }


        [MinLength(5), MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [DataType(DataType.ImageUrl)]
        public string EventBanner { get; set; }
    }
}
