using BanHangOgani.Models;
using BanHangOgani.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BanHangOgani.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private IProductRepository _productRepository;
        public DashboardController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            //1
            List<Product> lstProducts = _productRepository.GetAll();
            //2
            return View(lstProducts);
        }
    }
}
