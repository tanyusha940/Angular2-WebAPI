using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Models.Repositories;

namespace TestTask.Models
{
    public class UnitOfWork : IDisposable
    {
        private ProductContext db = new ProductContext();
        private ProductRepository productRepository;
        private BasketRepository basketRepository;

        public ProductRepository Product
        {
            get
            {
                if(productRepository ==null)
                    productRepository=new ProductRepository(db);
                return productRepository;
            }
        }
        public BasketRepository Basket
        {
            get
            {
                if (basketRepository == null)
                    basketRepository = new BasketRepository(db);
                return basketRepository;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}