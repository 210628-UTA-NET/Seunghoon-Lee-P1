using Microsoft.AspNetCore.Mvc;
using Seunghoon_Lee_P1.Models.DataLayer;
using Seunghoon_Lee_P1.Models.DataLayer.Repositories;
using Seunghoon_Lee_P1.Models.DomainModels;
using Seunghoon_Lee_P1.Models.DTOs;
using Seunghoon_Lee_P1.Models.ExtensionMethods;
using Seunghoon_Lee_P1.Models.Grid;
using Seunghoon_Lee_P1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Controllers
{
    public class ProductController : Controller
    {
        private UnitOfWork data { get; set; }
        public ProductController(P1Context context) => data = new UnitOfWork(context);

        public IActionResult Index() => RedirectToAction("ProductList");

        public ViewResult ProductList(ProductGridDTO p_griddto)
        {
            var builder = new ProductsGridBuilder(HttpContext.Session, p_griddto, defaultSortFilter: nameof(Product.Name));

            var options = new ProductQueryOptions
            {
                Includes = "Inventories.Store, Brand, Category",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };

            options.SortFilter(builder);

            var viewModel = new ProductListViewModel
            {
                Products = data.Products.List(options),
                Stores = data.Stores.List(new QueryOptions<Store> { OrderBy = s => s.Name }),
                Brands = data.Brands.List(new QueryOptions<Brand> { OrderBy = b => b.Name }),
                Categories = data.Categories.List(new QueryOptions<Category> { OrderBy = c => c.Name }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Products.Count)
            };

            return View(viewModel);
        }

        public ViewResult ProductDetail(int id)
        {
            var product = data.Products.Get(new QueryOptions<Product>
            {
                Includes = "Inventories.Store, Brand, Category",
                Where = p => p.ProductId == id
            });

            return View(product);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new ProductsGridBuilder(HttpContext.Session);
            if (clear)
                builder.ClearFilterSegments();
            else
            {
                var store = data.Stores.Get(filter[0].ToInt());
                builder.CurrentRoute.PageNumber = 1;
                builder.LoadFilterSegments(filter, store);
            }

            builder.SaveRouteSegment();
            return RedirectToAction("ProductList", builder.CurrentRoute);
        }

        [HttpPost]
        public RedirectToActionResult PageSize(int pagesize)
        {
            var builder = new ProductsGridBuilder(HttpContext.Session);

            builder.CurrentRoute.PageSize = pagesize;
            builder.SaveRouteSegment();

            return RedirectToAction("List", builder.CurrentRoute);
        }

    }
}
