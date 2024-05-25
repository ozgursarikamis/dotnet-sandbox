using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class AddProductModel : PageModel
    {
	    public WiredContext WiredContext;
	    public IWebHostEnvironment WebHostEnvironment { get; set; }

		public AddProductModel(
		    WiredContext wiredContext,
		    IWebHostEnvironment webHostEnvironment
			)
	    {
		    WiredContext = wiredContext;
			WebHostEnvironment = webHostEnvironment;
		}
		
	    [BindProperty]
	    public Product NewProduct { get; set; }

        public void OnGet()
		{

		}

        public async Task<IActionResult> OnPost()
        {
	        if (!ModelState.IsValid) return Page();

	        if (NewProduct.Upload is null) return RedirectToPage("ViewAllProducts");

	        NewProduct.ImageFileName = NewProduct.Upload.FileName;
	        var filePath = Path.Combine(WebHostEnvironment.ContentRootPath, "wwwroot/images/menu", NewProduct.Upload.FileName);
	        await using var fileStream = new FileStream(filePath, FileMode.Create);
	        await NewProduct.Upload.CopyToAsync(fileStream);

	        NewProduct.Created = DateTime.Now;
	        WiredContext.Products.Add(NewProduct);
	        await WiredContext.SaveChangesAsync();

	        return RedirectToPage("ViewAllProducts");
		}
	}
}
