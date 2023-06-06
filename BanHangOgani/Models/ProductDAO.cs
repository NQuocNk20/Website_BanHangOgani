

namespace BanHangOgani.Models
{
    public class ProductDAO
    {
        private QuanLiBanHangContext _ctx;

        public ProductDAO()
        {
            _ctx = new QuanLiBanHangContext();
        }

        public List<Product> getAllProduct()
        {
            //select * from Products
            return _ctx.Products.ToList();
        }
        public List<Product> getTop5byPrice()
        {
            //select * from Products
            return _ctx.Products.OrderByDescending(x => x.PorductRate).Take(5).ToList();
        }

        public Boolean CreateProduct(Product product)
        {
            _ctx.Products.Add(product);
            _ctx.SaveChanges();
            return true;
        }
        public Boolean UpdateProduct(Product updateProduct)
        {

            //1 findByID
            Product product = _ctx.Products.Where(x => x.ProductId == updateProduct.ProductId).SingleOrDefault();
            //2. change data
            product.PorductRate = updateProduct.PorductRate; 
            product.ProductDescription = updateProduct.ProductDescription;
            //3.update
            _ctx.Products.Update(product);
            _ctx.SaveChanges();
            return true;
        }
        public Boolean DeleteProduct(String ProductId)
        {
            //1 findByID
            Product product = _ctx.Products.Where(x => x.ProductId == ProductId).SingleOrDefault();
            _ctx.Products.Remove(product);
            _ctx.SaveChanges();
            return true;
        }
    }
}
