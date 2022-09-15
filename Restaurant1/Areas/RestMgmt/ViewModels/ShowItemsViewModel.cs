using Restaurant1.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Restaurant1.Areas.RestMgmt.ViewModels
{
    public class ShowItemsViewModel
    {
        [Display(Name = "Select Category:")]
        [Required(ErrorMessage = "Please select a category for displaying the items")]
        public int CategoryId { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
