using Microsoft.AspNetCore.Mvc;
using WiredBrainCoffeeAdmin.Data;

namespace WiredBrainCoffeeAdmin.Components
{
	public class ProductListViewComponent : ViewComponent
	{
		public IProductRepository ProductRepository { get; }

		public ProductListViewComponent(IProductRepository productRepository)
		{
			this.ProductRepository = productRepository;
		}

		public IViewComponentResult Invoke()
		{
			var items = ProductRepository.GetAll();
			return View(items);
		}
	}
}
