using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Seunghoon_Lee_P1.Areas.Admin.Models;
using Seunghoon_Lee_P1.Models.DataLayer;
using Seunghoon_Lee_P1.Models.DataLayer.Repositories;
using Seunghoon_Lee_P1.Models.DomainModels;

namespace Seunghoon_Lee_P1.Areas.Admin.Controllers
{
  [Authorize(Roles = "Admin")]
  [Area("Admin")]
  public class ProductController : Controller
  {
    private UnitOfWork data { get; set; }
    public ProductController(P1Context ctx) => data = new UnitOfWork(ctx);

    public IActionResult Index()
    {
      var search = new SearchData(TempData);
      search.Clear();
      return View();
    }

    [HttpGet]
    public ViewResult Add(int id) => GetProduct(id, "Add");

    [HttpPost]
    public IActionResult Add(ProductViewModel vm)
    {
      if (ModelState.IsValid)
      {
        data.AddNewInventories(vm.Product, vm.SelectedStores);
        data.Products.Insert(vm.Product);
        data.Save();

        TempData["message"] = $"{vm.Product.Name} was added to Products";
        return RedirectToAction("Index");
      }
      else
      {
        Load(vm, "Add");
        return View("Product", vm);
      }
    }

    [HttpGet]
    public ViewResult Edit(int id) => GetProduct(id, "Edit");

    [HttpPost]
    public IActionResult Edit (ProductViewModel vm)
    {
      if (ModelState.IsValid)
      {
        data.DeleteCurrentInventories(vm.Product);
        data.AddNewInventories(vm.Product, vm.SelectedStores);
        data.Products.Update(vm.Product);
        data.Save();
        TempData["message"] = $"{vm.Product.Name} was updated";
        return RedirectToAction("Search");
      }
      else
      {
        Load(vm, "Edit");
        return View("Product", vm);
      }
    }

    [HttpGet]
    public ViewResult Delete(int id) => GetProduct(id, "Delete");

    [HttpPost]
    public IActionResult Delete(ProductViewModel vm)
    {
      data.Products.Delete(vm.Product); 
      data.Save();
      TempData["message"] = $"{vm.Product.Name} was deleted";
      return RedirectToAction("Search");
    }

    [HttpGet]
    public ViewResult Search()
    {
      var search = new SearchData(TempData);

      if (search.HasSearchTerm)
      {
        var vm = new SearchViewModel
        {
          SearchTerm = search.SearchTerm
        };

        var options = new QueryOptions<Product>
        {
          Includes = "Brand, Category, Inventories.Store"
        };

        if (search.IsProduct)
        {
          options.Where = p => p.Name.Contains(vm.SearchTerm);
          vm.Header = $"Search results for the product name '{vm.SearchTerm}'";
        }

        if (search.IsStore)
        {
          int index = vm.SearchTerm.LastIndexOf(' ');
          if (index == -1) 
          {
             options.Where = p => p.Inventories.Any(
              i => i.Store.Name.Contains(vm.SearchTerm));
          }
          else
          {
             string storename = vm.SearchTerm;
             options.Where = p => p.Inventories.Any(
              i => i.Store.Name.Contains(storename));
          }

          vm.Header = $"Search results for store '{vm.SearchTerm}'";
        }
        /*
        if (search.IsUser)
        {
          options.Where = u => u.UserId.Contains(vm.SearchTerm);
          vm.Header = $"Search results for the userId '{vm.SearchTerm}'";
        }
        */
        vm.Products = data.Products.List(options);
        return View("SearchResults", vm);
      }
      else
        return View("Index");
    }

    [HttpPost]
    public RedirectToActionResult Search(SearchViewModel vm)
    {
      if (ModelState.IsValid)
      {
        var search = new SearchData(TempData)
        {
          SearchTerm = vm.SearchTerm,
          Type = vm.Type
        };
        return RedirectToAction("Search");
      }
      else
        return RedirectToAction("Index");
    }

    private ViewResult GetProduct(int id, string operation)
    {
      var product = new ProductViewModel();
      Load(product, operation, id);
      return View("Product", product);
    }

    private void Load(ProductViewModel vm, string op, int? id = null)
    {
      if (Operation.IsAdd(op))
      {
        vm.Product = new Product();
      }
      else
      {
        vm.Product = data.Products.Get(new QueryOptions<Product>
        {
          Includes = "Inventories.Store, Brand, Category",
          Where = b => b.ProductId == (id ?? vm.Product.ProductId)
        });
      }

      vm.SelectedStores = vm.Product.Inventories?.Select(i => i.Store.StoreId).ToArray();
      vm.Stores = data.Stores.List(new QueryOptions<Store> { OrderBy = s => s.Name });
      vm.Category = data.Categories.List(new QueryOptions<Category> { OrderBy = c => c.Name });
    }
  }
}
