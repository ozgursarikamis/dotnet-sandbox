using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class AddProductModel : PageModel
    {
        [BindProperty]
	    public Product NewProduct { get; set; }

        public void OnGet()
		{

		}

        public IActionResult OnPost()
        {
	        if (!ModelState.IsValid) return Page();

	        // Save NewProduct to the database
            var productName = NewProduct.Name;
            return RedirectToPage("ViewAllProducts");
        }
	}
}
