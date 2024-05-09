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

        public void OnPost()
        {
            if (ModelState.IsValid)
            {
	            // Save NewProduct to the database
	            var productName = NewProduct.Name;
			}
            else
            {
                // Do something else.
            }
		}
	}
}
