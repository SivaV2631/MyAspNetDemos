using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Models
{
    [Table("CurrentJobStatuses")]
    public class CurrentJobStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CurrentJobStatusId { get; set; }

        [Display(Name ="Current Job Status")]
        [Required]
        [MinLength(2),MaxLength(100)]
        public string CurrentJobStatusName { get; set; }



        #region NAvigation Properties for Model - Employee
        public ICollection<Employee> Employees { get; set; }
        #endregion
    }
}
