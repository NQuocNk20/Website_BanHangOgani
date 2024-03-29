﻿using BanHangOgani.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BanHangOgani.Repository;
using BanHangOgani.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using BanHangOgani.Areas.Identity.Data;

namespace BanHangOgani.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductDAO _productDAO = new ProductDAO();
        private IProductRepository _productRepository;
        private readonly SignInManager<ApplicationUser> _signInManager;

        QuanLiBanHangContext db = new QuanLiBanHangContext();
 

        public HomeController(ILogger<HomeController> logger,
            IProductRepository productRepository,
             SignInManager<ApplicationUser> signInManager)
        {          
            _logger = logger;
            _productRepository = productRepository;
            _signInManager = signInManager;
        }

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

        /*    public IActionResult CategoryMenu()
            {
                var categories = _quanLiBanHangContext.Categories.ToList();

                return PartialView("_DropMenu", categories);
            }*/
   
        public IActionResult SanPhamTheoLoai(string categoryId)
        {
            List<Product> lstsanpham = db.Products.Where(x => x.CategoryId == categoryId).OrderBy(x => x.ProductName).ToList();
            return View(lstsanpham);
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


        public IActionResult ChiTietSanPham(string productId)
        {
            var sanPham = db.Products.Include(x => x.Category).SingleOrDefault(x => x.ProductId == productId);
            return View(sanPham);
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return LocalRedirect("/Home/Index");
        }
    }
}