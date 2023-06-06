using BanHangOgani.Models;
using BanHangOgani.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BanHangOgani.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private ICategoryReposistory _categoryRepository;
        private IProductRepository _productRepository;
        private IProductBrandRepository _brandRepository;


        public CategoryController(ICategoryReposistory categoryRepository,
                              IProductRepository productRepository,
                              IProductBrandRepository brandRepository)
        {
            _categoryRepository = categoryRepository;

            _productRepository = productRepository;
            _brandRepository = brandRepository;
        }


        public IActionResult ViewAllCategories()
        {
            //1 get data
            List<Category> lst = _categoryRepository.GetAll();
            //2 passing data to view

            return View("ViewAllCategories", lst);
        }

        [HttpPost]
        public IActionResult saveCategory(Category category)
        {
            if (ModelState.IsValid)
            {

                //check name in db
                bool isCategoryNameExist = _categoryRepository.checkName(category.Ncategory);

                if (isCategoryNameExist)
                {
                    ModelState.AddModelError(string.Empty, "CategoryName is Exist!!!");
                    return View("CreateCategory");
                }
                else
                {
                    _categoryRepository.Create(category);
                    return RedirectToAction("ViewAllCategories");
                }

            }
            else
            {

                return View("CreateCategory");
            }



        }
        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View("createCategory", new Category());
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var q1 = from c in _categoryRepository.GetAll()
                     select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                     {
                         Text = c.Ncategory,
                         Value = c.CategoryId
                     };
            var q2 = from c in _brandRepository.getAll()
                     select new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem()
                     {
                         Text = c.BrandName,
                         Value = c.BrandId
                     };

            ViewBag.CategoryId = q1.ToList();
            ViewBag.BrandId = q2.ToList();

            return View("CreateProduct", new Product());
        }

        public IActionResult EditCategory(string id)
        {
            return View("EditCategory", _categoryRepository.findByID(id));
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
            return RedirectToAction("ViewAllCategories");
        }
        public IActionResult DeleteCategory(string id)
        {
          /*  TempData["Message"] = "";*/
            _categoryRepository.Delete(id);
         /*   TempData["Message"] = "Sản phẩm đã được xóa";*/
            return RedirectToAction("ViewAllCategories");
        }
      
    }
}
