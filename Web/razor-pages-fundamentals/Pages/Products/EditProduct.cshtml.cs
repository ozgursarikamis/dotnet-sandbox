using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages.Products
{
    public class EditProductModel : PageModel
    {
	    private IProductRepository productRepo;
	    private IWebHostEnvironment webEnvironment;
		public EditProductModel(IProductRepository productRepo, IWebHostEnvironment webEnvironment)
		{
			this.productRepo = productRepo;
			this.webEnvironment = webEnvironment;
		}

		[BindProperty] public Product EditProduct { get; set; }

		[FromRoute] // populate this ONLY from the URL
		public int Id { get; set; }

		public void OnGet()
		{
			EditProduct = this.productRepo.GetById(Id);
		}

		public async Task<IActionResult> OnPostEdit()
		{
			if(!ModelState.IsValid) return Page();

			if (EditProduct.Upload is not null)
			{
				EditProduct.ImageFileName = EditProduct.Upload.FileName;

				var file = Path.Combine(webEnvironment.ContentRootPath, "wwwroot/images/menu",
					EditProduct.Upload.FileName);

				await using var reader = new FileStream(file, FileMode.Create);
				await EditProduct.Upload.CopyToAsync(reader);
			}

			EditProduct.Created = DateTime.Now;
			EditProduct.Id = Id;
            this.productRepo.Update(EditProduct);

            return RedirectToPage("ViewAllProducts");
		}

        public async Task<IActionResult> OnPostDelete2()
        {
            this.productRepo.Delete(Id);
            return RedirectToPage("ViewAllProducts");
        }
    }
}
