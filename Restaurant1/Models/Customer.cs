using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Restaurant1.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int CustomerId { get; set; }

        [Required(ErrorMessage ="Customer Name Cannot be Empty")]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Display(Name ="Phone No")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public  string CustomerPhone{ get; set; }


        [Display(Name ="Email")]
        [Required(ErrorMessage ="Email cannot be empty")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }



        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        public string CustomerCompliment { get; set; }


        #region Navigation Properties to - Orders

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; }

        #endregion
    }
}
