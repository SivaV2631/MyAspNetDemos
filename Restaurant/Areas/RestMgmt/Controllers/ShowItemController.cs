using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.Areas.RestMgmt.ViewModels;
using Restaurant.Data;

using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Restaurant.Areas.RestMgmt.Controllers
{
    [Area("RestMgmt")]
    public class ShowItemController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ShowItemController> _logger;

        public ShowItemController(
            ApplicationDbContext dbContext,
            ILogger<ShowItemController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        public IActionResult Index()
        {
            // ----- APPROACH #1 (ViewModel is sent containing the original data)
            //ShowBooksViewModel viewmodel = new ShowBooksViewModel();
            //viewmodel.Categories = _dbContext.Categories.ToList();
            //return View(viewmodel);


            // -----  APPROACH #2 (Array of SelectListItem is sent to the View)
            //List<SelectListItem> categories = new List<SelectListItem>();
            //var query = _dbContext.Categories.ToList();
            //foreach(var category in query)
            //{
            //    categories.Add(new SelectListItem(text: category.CategoryName, value: category.CategoryId.ToString()));
            //}

            PopulateDropDownListToSelectCategory();

            _logger.LogInformation("--- extracted Categories");
            return View();
        }

        private void PopulateDropDownListToSelectCategory()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem
            {
                Text = "----- select a category -----",
                Value = "",
                Selected = true
            });
            categories.AddRange(new SelectList(_dbContext.Categories, "CategoryId", "CategoryName"));

            ViewData["CategoriesCollection"] = categories;
        }

        // NOTE: Error messages added by Server-side code will disappear only on "SUBMIT"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("CategoryId")] ShowItemViewModel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                PopulateDropDownListToSelectCategory();

                // Something is wrong with the viewmodel.  So, just return it back to the view with the ModelState errors!
                return View(viewmodel);
            }

            // Now performing server-side validation - checking if any books exist for the selected category
            bool booksExist = _dbContext.Items.Any(b => b.CategoryId == viewmodel.CategoryId);
            if (!booksExist)
            {
                //--- Error will be shown as part of the Validation Summary
                ModelState.AddModelError("", "No items were found for the selected category!");

                //--- Error will be attached to the UI Control mapped by the asp-for attribute.
                // ModelState.AddModelError("CategoryId", "No books were found for this category");

                PopulateDropDownListToSelectCategory();
                return View(viewmodel);         // return the viewmodel with the ModelState errors!
            }

            return RedirectToAction(
                actionName: "GetItemsOfCategory",
                controllerName: "Items",
                routeValues: new { area = "RestMgmt", filterCategoryId = viewmodel.CategoryId });
        }

    }
}
