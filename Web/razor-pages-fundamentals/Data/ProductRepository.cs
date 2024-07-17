using Microsoft.EntityFrameworkCore;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Data
{
    public class ProductRepository : IProductRepository
    {
	    public WiredContext WiredContext { get; }

        public ProductRepository(WiredContext context)
        {
            this.WiredContext = context;
        }

        public void Add(Product product)
        {
            WiredContext.Products.Add(product);
            WiredContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var deleteItem = WiredContext.Products.FirstOrDefault(x => x.Id == id);
            WiredContext.Products.Remove(deleteItem);
            // WiredContext.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return WiredContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return WiredContext.Products.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Product product)
        {
            WiredContext.Entry(product).State = EntityState.Modified;
            WiredContext.SaveChanges();
        }
    }
}
