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
    public class StoreController : Controller
    {
        private Repository<Store> data { get; set; }
        public StoreController(P1Context context) => data = new Repository<Store>(context);
        
        public IActionResult Index() => RedirectToAction("StoreList");

        public ViewResult List(GridDTO g_dto)
        {
            string defaultSort = nameof(Store.Name);
            var builder = new GridBuilder(HttpContext.Session, g_dto, defaultSort);
            builder.SaveRouteSegment();

            var options = new QueryOptions<Store>
            {
                Includes = "Inventories.Product",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };

            options.OrderBy = s => s.Name;

            var viewModel = new StoreListViewModel
            {
                Stores = data.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Count)
            };

            return View(viewModel);
        }

        public ViewResult Details(int id)
        {
            var store = data.Get(new QueryOptions<Store>
            {
                Includes = "Inventories.Product",
                Where = s => s.StoreId == id
            });

            return View(store);
        }

    }
}
