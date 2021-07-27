using Seunghoon_Lee_P1.Models.DomainModels;
using Seunghoon_Lee_P1.Models.ExtensionMethods;
using Seunghoon_Lee_P1.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer
{
    //Extends QueryOptions<product> class
    //Add a SortFilter()
    public class ProductQueryOptions : QueryOptions<Product>
    {
        public void SortFilter(ProductsGridBuilder builder)
        {

            //Filters
            if (builder.IsFilterByBrand)
            {
                if (builder.IsFilterByStore)
                {
                    int id = builder.CurrentRoute.StoreFilter.ToInt();
                    if (id > 0)
                        Where = p => p.Inventories.Any(i => i.Store.StoreId == id);
                }
                if (builder.IsFilterByBrand)
                    Where = p => p.BrandId == builder.CurrentRoute.BrandFilter;
                if (builder.IsFilterByCategory)
                    Where = p => p.CategoryId == builder.CurrentRoute.CategoryFilter;
                if (builder.IsFilterByPrice)
                {
                    if (builder.CurrentRoute.PriceFilter == "under500")
                    {
                        Where = p => p.Price < 500;
                    }
                    else if (builder.CurrentRoute.PriceFilter == "500to1000")
                    {
                        Where = p => (p.Price >= 500 && p.Price < 1000);
                    }
                    else
                    {
                        Where = p => p.Price >= 1000;
                    }
                }
            }

            //Sorts
            if (builder.IsSortByBrand)
                OrderBy = p => p.Brand.Name;
            else if (builder.IsSortByCategory)
                OrderBy = p => p.Category.Name;
            else if (builder.IsSortByPrice)
                OrderBy = p => p.Price;
            else
                OrderBy = p => p.Name;
        }
    }
}
