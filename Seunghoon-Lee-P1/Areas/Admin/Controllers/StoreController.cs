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
  [Authorize(Roles ="Admin")]
  [Area("Admin")]
  public class StoreController : Controller
  {
    private Repository<Store> data { get; set; }
    public StoreController(P1Context ctx) => data = new Repository<Store>(ctx);

    public ViewResult Index()
    {
      var stores = data.List(new QueryOptions<Store>
      {
        OrderBy = s => s.Name
      });

      return View(stores);
    }

    public RedirectToActionResult Select(int id, string operation)
    {
      switch (operation.ToLower())
      {
        case "view products":
          return RedirectToAction("ViewProducts", new { id });
        case "edit":
          return RedirectToAction("Edit", new { id });
        case "delete":
          return RedirectToAction("Delete", new { id });
        default:
          return RedirectToAction("Index");
      }
    }

    private RedirectToActionResult GoToStoreSearch(Store store)
    {
      var search = new SearchData(TempData)
      {
        SearchTerm = store.Name,
        Type = "store"
      };

      return RedirectToAction("Search", "Product");
    }


    public RedirectToActionResult ViewProducts(int id)
    {
      var store = data.Get(id);
      return GoToStoreSearch(store);
    }

    [HttpGet]
    public ViewResult Add() => View("Store", new Store());

    [HttpPost]
    public IActionResult Add(Store store, string operation)
    {
      var validate = new Validate(TempData);
      if (!validate.IsStoreChecked)
      {
        validate.CheckStore(store.Name, operation, data);
        if (!validate.IsValid)
        {
          ModelState.AddModelError(nameof(store.Name), validate.ErrorMessage);
        }
      }

      if (ModelState.IsValid)
      {
        data.Insert(store);
        data.Save();
        validate.ClearStore();
        TempData["message"] = $"{store.Name} was added in the database";
        return RedirectToAction("Index");
      }
      else
        return View("Store", store);
    }

    [HttpGet]
    public ViewResult Edit(int id) => View("Store", data.Get(id));

    [HttpPost]
    public IActionResult Edit(Store store)
    {
      if (ModelState.IsValid)
      {
        data.Update(store);
        data.Save();
        TempData["message"] = $"{store.Name} was updated";
        return RedirectToAction("Index");
      }
      else
        return View("Store", store);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
      var store = data.Get(new QueryOptions<Store>
      {
        Includes = "Inventories",
        Where = a => a.StoreId == id
      });

      if (store.Inventories.Count > 0)
      {
        TempData["message"] = $"Can't delete store {store.Name} because the store is associated with these products.";
        return GoToStoreSearch(store);
      }
      else
      {
        return View("Store", store);
      }
    }

    [HttpPost]
    public RedirectToActionResult Delete(Store store)
    {
      data.Delete(store);
      data.Save();
      TempData["message"] = $"{store.Name} was deleted";
      return RedirectToAction("Index");
    }
  }
}
