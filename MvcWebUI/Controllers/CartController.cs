using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.DomainModels;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;
using System.Linq;

namespace MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionHelper _cartSessionHelper;
        private IProductService _productService;

        private ICartService _cartService;

        public CartController(ICartService cartService, ICartSessionHelper cartSessionHelper,
            IProductService productService)
        {
            _cartService = cartService;
            _cartSessionHelper = cartSessionHelper;
            _productService = productService;
        }

        public IActionResult AddToCart(int productId)
        {
            //ürünü çek
            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("cart");
            _cartService.AddToCart(cart, product);

            _cartSessionHelper.SetCart("cart", cart);

            TempData.Add("message", product.ProductName + " Sepete Eklendi!");

            return RedirectToAction("Index", "Product");

        }

        public IActionResult Index()
        {
            var model = new CartListViewModel
            {
                Cart = _cartSessionHelper.GetCart("cart")
            };

            return View(model);
        }

        public IActionResult RemoveFromCart(int productId)
        {


            Product product = _productService.GetById(productId);

            var cart = _cartSessionHelper.GetCart("cart");


            _cartService.RemoveFromCart(cart, productId);

            _cartSessionHelper.SetCart("cart", cart);
            CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);


            if (cartLine == null)
            {
                TempData.Add("message", product.ProductName + " Sepetten Silindi!");

            }
            else
            {
                TempData.Add("message", product.ProductName + " 1 tane Sepetten Silindi!");
            }

            return RedirectToAction("Index", "Cart");
        }

        public IActionResult Complete()

        {
            var model = new ShippingDetailsViewModel
            {
                ShippingDetail = new ShippingDetail()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetail shippingDetail)
        {
            TempData.Add("message", "Siparişiniz başarıyla tamamlandı");
            _cartSessionHelper.Clear();
            return RedirectToAction("Index", "Cart");
        }



    }
}

