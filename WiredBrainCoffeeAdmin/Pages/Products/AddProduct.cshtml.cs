using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class AddProductModel : PageModel
    {
	    public WiredContext WiredContext;

	    public AddProductModel(WiredContext wiredContext)
	    {
		    WiredContext = wiredContext;
	    }

	    [BindProperty]
	    public Product NewProduct { get; set; }

        public void OnGet()
		{

		}

        public IActionResult OnPost()
        {
	        if (!ModelState.IsValid) return Page();

			WiredContext.Products.Add(NewProduct);
			var changes = WiredContext.SaveChanges();

            return RedirectToPage("ViewAllProducts");
        }
	}
}
