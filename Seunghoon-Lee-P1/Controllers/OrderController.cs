using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seunghoon_Lee_P1.Models.DataLayer;
using Seunghoon_Lee_P1.Models.DataLayer.Repositories;
using Seunghoon_Lee_P1.Models.DomainModels;
using Seunghoon_Lee_P1.Models.DTOs;
using Seunghoon_Lee_P1.Models.Grid;
using Seunghoon_Lee_P1.Models.ViewModels;

namespace PavolsBookStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private Repository<Product> data { get; set; }

        public OrderController(P1Context context) => data = new Repository<Product>(context);

        private Order GetOrder()
        {
            var order = new Order(HttpContext);
            order.Load(data);
            return order;
        }

        public IActionResult Index()
        {
            Order order = GetOrder();

            var builder = new ProductsGridBuilder(HttpContext.Session);

            var viewModel = new OrderViewModel
            {
                LineItems = order.List,
                SubTotal = order.SubTotal,
                ProductGridRoute = builder.CurrentRoute
            };

            return View(viewModel);
        }

        [HttpPost]
        public RedirectToActionResult Add(int id)
        {
            var product = data.Get(new QueryOptions<Product>
            {
                Includes = "Inventories.Store, Brand, Category",
                Where = p => p.ProductId == id
            });

            if (product == null)
            {
                TempData["message"] = "Unable to add product to cart";
            }
            else
            {
                var dto = new ProductDTO();
                dto.Load(product);
                LineItem item = new LineItem
                {
                    Product = dto,
                    Quantity = 1 
                };

                Order order = GetOrder();
                order.Add(item);
                order.Save();

                TempData["message"] = $"{product.Name} was added to cart";
            }

            var builder = new ProductsGridBuilder(HttpContext.Session);
            return RedirectToAction("ProductList", "Product", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult Remove(int id)
        {
            Order order = GetOrder();
            LineItem item = order.GetById(id);
            order.Remove(item);
            order.Save();

            TempData["message"] = $"{item.Product.Name} was removed from the cart";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public RedirectToActionResult Clear()
        {
            Order order = GetOrder();
            order.Clear();
            order.Save();

            TempData["message"] = "Cart has been cleared";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Order order = GetOrder();
            LineItem item = order.GetById(id);

            if (item == null)
            {
                TempData["message"] = "Unable to locate cart item";
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        [HttpPost]
        public RedirectToActionResult Edit(LineItem item)
        {
            Order order = GetOrder();
            order.Edit(item);
            order.Save();

            TempData["message"] = $"{item.Product.Name} has been updated";
            return RedirectToAction("Index");
        }

        public ViewResult Checkout() => View();
    }
}
