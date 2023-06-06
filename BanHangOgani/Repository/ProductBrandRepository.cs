using BanHangOgani.Models;

namespace BanHangOgani.Repository
{
    public interface IProductBrandRepository
    {
            public List<ProductBrand> getAll();
        }
        public class ProductBrandRepository : IProductBrandRepository
        {
            private QuanLiBanHangContext _ctx;
            public ProductBrandRepository(QuanLiBanHangContext ctx)
            {
                _ctx = ctx;
            }
            public List<ProductBrand> getAll()
            {
                return _ctx.ProductBrands.ToList();
            }
        }
}

