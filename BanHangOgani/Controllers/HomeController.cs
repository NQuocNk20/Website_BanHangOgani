using BanHangOgani.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BanHangOgani.Repository;

namespace BanHangOgani.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductDAO _productDAO = new ProductDAO();
        private IProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger,
            IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

     /*   public IActionResult findProductsByCategoryId(string id)
        {
            List<Product> products = _productRepository.findProductsByCategoryId(id);


            return View(products);
        }*/

     /*   public IActionResult Index()
        {
            //1 . lay du lieu
            List<Product> danhsachsanpham = _productDAO.getAllProduct();
            //2. gui du lieu cho view

            return View(danhsachsanpham);
        }*/



        public IActionResult Index(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 8; // Kích thước trang

            List<Product> danhsachsanpham = _productDAO.getAllProduct();

            var pagedData = danhsachsanpham.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = danhsachsanpham.Count;

            return View(pagedData.ToList());
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}