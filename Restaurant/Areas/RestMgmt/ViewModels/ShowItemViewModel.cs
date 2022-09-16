using Restaurant.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Areas.RestMgmt.ViewModels
{
    public class ShowItemViewModel
    {
        [Display(Name = "Select Category:")]
        [Required(ErrorMessage = "Please select a category for displaying the items")]
        public int CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
