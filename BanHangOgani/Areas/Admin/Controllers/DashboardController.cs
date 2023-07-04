using BanHangOgani.Areas.Identity.Data;
using BanHangOgani.Models;
using BanHangOgani.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace BanHangOgani.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class DashboardController : Controller
    {
        private IProductRepository _productRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public DashboardController(IProductRepository productRepository,
            SignInManager<ApplicationUser> signInManager)
        {
            _productRepository = productRepository;
            _signInManager = signInManager;
        }
        /*[AllowAnonymous]*/
        public IActionResult Index()
        {
            //1
            List<Product> lstProducts = _productRepository.GetAll();
            //2
            return View(lstProducts);
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return LocalRedirect("/indentity/account/login");
        }
    }
}
