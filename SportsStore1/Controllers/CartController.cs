using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsStore1.Infrastructure;
using SportsStore1.Models;
using Newtonsoft.Json;
using SportsStore1.Models.ViewModels;

namespace SportsStore1.Controllers
{
    public class CartController:Controller
    {
        public CartController(IProductRepository repo)
        {
            repository = repo;
        }
        private IProductRepository repository;

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCard(),
                ReturnUrl = returnUrl
            });
        }
        private Cart GetCard()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
            
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }
        public RedirectToActionResult AddToCart(int productId,string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                Cart cart = GetCard();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId,string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                Cart cart = GetCard();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}
