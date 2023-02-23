using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JobPortal1.Models
{
    [Table("UserTables")]
    public class UserTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }


        [Required(ErrorMessage = "${0} Cannot be empty")]
        [StringLength(50)]
        public string UserName { get; set; }


        [Required, DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "password needs mininmum 8 characters")]
        public string Password { get; set; }


        [DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Not Matched with Password")]
        [MinLength(8, ErrorMessage = "password needs mininmum 8 characters")]
        public string ConfirmPassword { get; set; }


        [Required, DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }


        [Required, DataType(DataType.PhoneNumber)]
        [MinLength(10, ErrorMessage = "Invalid phone number"), MaxLength(13)]
        public string ContactNo { get; set; }



        #region Navigation Properties to the Master Model - UserType

        [Required]
        public int UserTypeId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(UserTable.UserTypeId))]
        public UserType UserType { get; set; }

        #endregion



        #region Navigation Properties to the Master Model - AccountStatus

        [Required]
        public int AccountStatusId { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(UserTable.AccountStatusId))]
        public AccountStatus AccountStatus { get; set; }

        #endregion


        #region  #region Navigation Properties to the  Model - Company

        public ICollection<Company> Companies { get; set; }

        #endregion


        #region Navigation Properties to the  Model - PostJob

        public ICollection<PostJob> PostJobs { get; set; }

        #endregion


    }
}
