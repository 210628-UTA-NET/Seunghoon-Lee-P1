using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seunghoon_Lee_P1.Areas.Admin.Models;
using Seunghoon_Lee_P1.Models.DataLayer;
using Seunghoon_Lee_P1.Models.DataLayer.Repositories;
using Seunghoon_Lee_P1.Models.DomainModels;

namespace Seunghoon_Lee_P1.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class ValidationController : Controller
  {
    private Repository<Store> storeData { get; set; }
    private Repository<Category> categoryData { get; set; }

    public ValidationController(P1Context ctx)
    {
      storeData = new Repository<Store>(ctx);
      categoryData = new Repository<Category>(ctx);
    }

    public JsonResult CheckCategory(string categoryId)
    {
      var validate = new Validate(TempData);
      validate.CheckCategory(categoryId, categoryData);
      if (validate.IsValid)
      {
        validate.MarkCategoryChecked();
        return Json(true);
      }
      else
        return Json(validate.ErrorMessage);
    }

    public JsonResult CheckStore(string Name, string operation)
    {
      var validate = new Validate(TempData);
      validate.CheckStore(Name, operation, storeData);
      if (validate.IsValid)
      {
        validate.MarkStoreChecked();
        return Json(true);
      }
      else
        return Json(validate.ErrorMessage);
    }
  }
}
