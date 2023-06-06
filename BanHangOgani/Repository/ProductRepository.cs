using BanHangOgani.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace BanHangOgani.Repository
{
    public interface IProductRepository
    {
        public bool Create(Product product);
        public bool Update(Product product);    
        public bool Delete(string productId);
        public List<Product> GetAll();
        public List<Product> GetAllProductsByCategoryId(string id);
        public Product findByID(string id);


        public bool checkName(string name);
    }

    public class ProductRepository : IProductRepository
    {
        private QuanLiBanHangContext _ctx;
        public ProductRepository(QuanLiBanHangContext ctx)
        {    
            _ctx = ctx;
        }
        public bool Create(Product product) { 
            try
            {
                _ctx.Products.Add(product);
                _ctx.SaveChanges();
            }
            catch (Exception e) { 
                return false;
            }
            return true;
        }

        public bool Update(Product product)
        {
            Product c = _ctx.Products.FirstOrDefault(x => x.ProductId == product.ProductId);
            if (c != null)
            {
                _ctx.Entry(c).CurrentValues.SetValues(product);
                _ctx.SaveChanges();

            }
            return true;
        }
        public bool Delete(string productId)
        {
            //find id
            Product c = _ctx.Products.FirstOrDefault(x => x.ProductId == productId);
            _ctx.Products.Remove(c);
            _ctx.SaveChanges();
            return true;
        }

        public List<Product> GetAllProductsByCategoryId(string id)
        {
            return _ctx.Products.Where(x => x.CategoryId == id).ToList();
        }

        public List<Product> GetAll()
        {
            return _ctx.Products.ToList();
        }

        public Product findByID(string id)
        {
            Product c = _ctx.Products.FirstOrDefault(x => x.ProductId == id);
            return c;
        }

        public bool checkName(string name)
        {
            Product c = _ctx.Products.Where(x => x.ProductName.Trim() == name.Trim()).FirstOrDefault();
            if (c == null)
                return false;
            else
                return true;
        }
    }
}
