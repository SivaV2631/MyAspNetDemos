using System;
using System.ComponentModel.DataAnnotations;


namespace MyAspDemos.Areas.Demo.ViewModels
{
    public class EmployeeForm
    {
        [Display(Name = "Employee ID")]
        [Required]
        public int CustomerId { get; set; }


        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "{0} Cannot be empty!")]
        [MaxLength(80, ErrorMessage = "{0} can contain a maximum of {4} characters.")]
        [MinLength(2, ErrorMessage = "{0} should contain a minimum of {1} characters.")]
        public string CustomerName { get; set; }


      

        [Required(Name = "Phone number cannot be empty")
        [Display(Name = "Phone number should contain 10 digits ")]
        [Display(Name = "Phone number should contain only digits")
        public int Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "{0} is not valid.")]
        [EmailAddress(ErrorMessage = "{0} Should Contain @ or 1 Symbol")]
        public string Email { get; set; }


        [Required(Name = "Password cannot be empty")]
        [Password(ErrorMessage = "{0} is not valid.")]
        [Password(ErrorMessage = "{0} Should Contain 1 Upper, 1 Lower, 1 Symbol")]
        public string Password { get; set; }


        [Required(Name = "Password cannot be empty")]
        [ConfirmPassword(ErrorMessage = "{0} is not matched.")]
        [ConfirmPassword(ErrorMessage = "{0} Should Contain 1 Upper, 1 Lower, 1 Symbol")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Customer was Logged on")]
        [Required]
        public DateTime LoggedOn { get; set; }


        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
