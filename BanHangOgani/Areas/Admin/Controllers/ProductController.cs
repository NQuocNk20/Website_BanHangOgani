using BanHangOgani.Models;
using BanHangOgani.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BanHangOgani.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private IProductBrandRepository _brandRepository;
        private ICategoryReposistory _categoryReposistory;

        public ProductController(IProductRepository productRepository, IProductBrandRepository brandRepository,
            ICategoryReposistory categoryReposistory)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _categoryReposistory = categoryReposistory;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*       public IActionResult ViewAllProducts()
               {

                   //1 get data
                   List<Product> lst = _productRepository.GetAll();
                   //2 passing data to view

                   return View("ViewAllProducts", lst);
               }*/

        public IActionResult ViewAllProducts(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 8; // Kích thước trang

            List<Product> lst = _productRepository.GetAll();

            var pagedData = lst.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalItems = lst.Count;


            return View(pagedData.ToList());
        }





        [HttpPost]
        public IActionResult saveProduct(Product product)
        {
            if (ModelState.IsValid)
            {

                //check name in db
                bool isProductNameExist = _productRepository.checkName(product.ProductName);

                if (isProductNameExist)
                {
                    ModelState.AddModelError(string.Empty, "productName is Exist!!!");
                    return View("CreateProduct");
                }
                else
                {
                    _productRepository.Create(product);
                    return RedirectToAction("ViewAllProducts");
                }

            }
            else
            {

                return View("CreateProduct");
            }



        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var cateList = _categoryReposistory.GetAll();
            ViewBag.CategoryId = new SelectList(cateList, "CategoryId", "Ncategory");
            return View("createproduct", new Product());
        }


        public IActionResult EditProduct(string id)
        {
            var cateList = _categoryReposistory.GetAll();
            ViewBag.CategoryId = new SelectList(cateList, "CategoryId", "Ncategory");
            return View("EditProduct", _productRepository.findByID(id));
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            _productRepository.Update(product);
            return RedirectToAction("ViewAllProducts");
        }

        public IActionResult DeleteProduct(string id)
        {
            TempData["Message"] = "";
            _productRepository.Delete(id);
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("ViewAllProducts");
        }

    
    }
}
