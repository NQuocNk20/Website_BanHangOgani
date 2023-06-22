using BanHangOgani.Models;
using BanHangOgani.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BanHangOgani.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Cart()
        {
            ViewBag.sessionId = HttpContext.Session.Id;
            CartModel cartModel = new CartModel();
            cartModel.CartId = HttpContext.Session.Id;
            if (HttpContext.Session.Get<List<Item>>("cart") != null)
            {
                List<Item>? items = HttpContext.Session.Get<List<Item>>("cart");
                cartModel.setAllItems(items);
            }
            return View(cartModel);
        }
        public IActionResult AddToCart(string id)
        {
            Product product = _productRepository.findByID(id);
            int quantity = 1;
            CartModel cartModel = null;
            if (HttpContext.Session.Get<List<Item>>("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
                cartModel.setAllItems(HttpContext.Session.Get<List<Item>>("cart"));
            }
            else
            {
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
            }
            Item item = new Item()
            {
                Id = product.ProductId,
                Name = product.ProductName,
                Price = (decimal)product.ProductPrice,
                ImagePath = product.ProductImgPath,
                Quantity = quantity,
                lineTotal = (decimal)product.ProductPrice * quantity,
            };
            cartModel.addItem(item);
            //save to session
            HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());
            return RedirectToAction("Cart");
        }
        public IActionResult UpdateQuantity()
        {
            var btn = Request.Form["btnUpdateQuantity"].ToString();
            var id = Request.Form["item.Id"].ToString();
            var qty = Request.Form["item.Quantity"].ToString();
            CartModel cartModel = null;
            if (HttpContext.Session.Get<List<Item>>("cart") != null)
            {
                cartModel = new CartModel();
                cartModel.CartId = HttpContext.Session.Id;
                cartModel.setAllItems(HttpContext.Session.Get<List<Item>>("cart"));
            }
            cartModel.UpdateQuantity(id, 1, btn);
            HttpContext.Session.Set<List<Item>>("cart", cartModel.getAllItems());
            return RedirectToAction("Cart");
        }
        public ActionResult Checkout()
        {
            List<Item>? items = HttpContext.Session.Get<List<Item>>("cart");
            // 1 => shoppingcart
            // 2 => insert order
            foreach (var item in items)
            {

                // 3 => insert orderdetails
            }
            return View();
        }
    }
}
