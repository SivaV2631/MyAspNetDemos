using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal1.Models
{
    [Table("AccountStatuses")]
    public class AccountStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountStatusId { get; set; }

        [Required(ErrorMessage = "{0} Cannot be empty")]
        [StringLength(100, ErrorMessage = "{0} Cannot have more than {1} Characters")]
        public string AccountStatusName { get; set; }

        #region NAvigation properties for model - UserTable

        public ICollection<UserTable> UserTables { get; set; }
        #endregion
    }
}
