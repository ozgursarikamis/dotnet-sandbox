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

		public IViewComponentResult Invoke(int itemCount)
		{
			var items = ProductRepository.GetAll();
			if (itemCount > 0)
			{
				return View(items.Take(itemCount).ToList());
			}

			return View(items);
		}
	}
}
