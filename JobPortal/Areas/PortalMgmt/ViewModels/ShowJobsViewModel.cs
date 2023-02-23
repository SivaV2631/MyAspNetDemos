using JobPortal.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JobPortal.Areas.PortalMgmt.ViewModels
{
    public class ShowJobsViewModel
    {
        [Display(Name = "Select Category:")]
        [Required(ErrorMessage = "Please select a category for displaying the books")]
        public int JobCategoryId { get; set; }

        public ICollection<JobCategory> JobCategories { get; set; }
    }
}


