using System;
using System.ComponentModel.DataAnnotations;


namespace MyAspDemos.Areas.Demo.ViewModels
{ 

   
    public class EmployeeFormViewModel
    {
        [Display(Name = "Employee ID")]
        [Required]
        public int EmployeeId { get;  set; }


        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "{0} Cannot be empty!")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets  allowed.")]
        [MaxLength(80, ErrorMessage = "{0} can contain a maximum of {1} characters.")]
        [MinLength(2, ErrorMessage = "{0} should contain a minimum of {1} characters.")]
        public string EmployeeName { get; set; }  

        [Required(ErrorMessage = "email is required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email
        {
            get;
            set;
        } = "";


        [Display(Name ="Mobile No")]
        [Required(ErrorMessage = "Mobile is required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Please enter 10 digit Mobile No.")]
        public string Phone
        {
            get;
            set;
        } = "";

        [Display(Name ="Password")]
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6,ErrorMessage ="Minimum {1} Characters Needed")]
        [DataType(DataType.Password)]
        public string Password
        {
            get;
            private set;
        } 

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        [MinLength(6, ErrorMessage = "Minimum {1} Characters Needed")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword
        {
            get;
            private set;
        } 



        [Display(Name = "Employee was Logged on")]
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime LoggedOn { get; set; }


        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
