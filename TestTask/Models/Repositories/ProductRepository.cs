using System.Data.Entity;
using System.Linq;
using TestTask.Models.Repositories.Interfaces;

namespace TestTask.Models.Repositories
{
    public class ProductRepository:IRepository<Product>
    {
        private ProductContext db;
        public IQueryable<Product> GetAll()
        {
            return db.Products;
        }

        public ProductRepository(ProductContext context)
        {
            this.db = context;
        }
        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
            {
                db.Products.Remove(product);
            }
        }
    }
}