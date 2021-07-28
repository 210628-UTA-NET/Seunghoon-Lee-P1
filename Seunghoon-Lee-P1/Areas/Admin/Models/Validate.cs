using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Seunghoon_Lee_P1.Models.DataLayer;
using Seunghoon_Lee_P1.Models.DataLayer.Repositories;
using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Areas.Admin.Models
{
    public class Validate
    {
        private const string CategoryKey = "validCategory";
        private const string StoreKey = "validStore";

        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }

        public void CheckCategory(string categoryId, Repository<Category> data)
        {
            Category entity = data.Get(categoryId);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : $"Category Id {categoryId} is already in the database";
        }

        public void MarkCategoryChecked() => tempData[CategoryKey] = true;
        public void ClearCategory() => tempData.Remove(CategoryKey);
        public bool IsCategoryChecked => tempData.Keys.Contains(CategoryKey);

        //author
        public void CheckStore(string Name, string operation, Repository<Store> data)
        {
            Store entity = null; 
            if (Operation.IsAdd(operation))
            {
                entity = data.Get(new QueryOptions<Store>
                {
                    Where = a => a.Name == Name
                });
            }

            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : $"Store {entity.Name} is already in the database";
        }

        public void MarkStoreChecked() => tempData[StoreKey] = true;
        public void ClearStore() => tempData.Remove(StoreKey);
        public bool IsStoreChecked => tempData.Keys.Contains(StoreKey);
    }
}
