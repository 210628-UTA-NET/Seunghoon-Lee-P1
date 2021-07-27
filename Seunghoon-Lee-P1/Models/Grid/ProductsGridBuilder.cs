using Microsoft.AspNetCore.Http;
using Seunghoon_Lee_P1.Models.DomainModels;
using Seunghoon_Lee_P1.Models.DTOs;
using Seunghoon_Lee_P1.Models.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.Grid
{
    public class ProductsGridBuilder : GridBuilder
    {
        public ProductsGridBuilder(ISession p_session) 
            : base(p_session) { }
        public ProductsGridBuilder(ISession p_session, ProductGridDTO p_griddto, string defaultSortFilter) 
            : base(p_session, p_griddto, defaultSortFilter)
        {
            bool isInitial = p_griddto.Brand.IndexOf(FilterPrefix.Brand) == -1;
            Routes.StoreFilter = (isInitial) ? FilterPrefix.Store + p_griddto.Store : p_griddto.Store;
            Routes.BrandFilter = (isInitial) ? FilterPrefix.Brand + p_griddto.Brand : p_griddto.Brand;
            Routes.CategoryFilter = (isInitial) ? FilterPrefix.Category + p_griddto.Category : p_griddto.Category;
            Routes.PriceFilter = (isInitial) ? FilterPrefix.Price + p_griddto.Price : p_griddto.Price;

            SaveRouteSegment();
        }

        public void LoadFilterSegments(string[] filter, Store store)
        {
            if (store == null)
                Routes.StoreFilter = FilterPrefix.Store + filter[0];
            else
                Routes.StoreFilter = FilterPrefix.Store + filter[0] + "-" + store.Name.Slug();
            Routes.BrandFilter = FilterPrefix.Brand + filter[1];
            Routes.CategoryFilter = FilterPrefix.Category + filter[2];
            Routes.PriceFilter = FilterPrefix.Price + filter[3];
        }

        public void ClearFilterSegments() => Routes.ClearFilters();

        //Filter flags
        string df = ProductGridDTO.DefaultFilter;
        public bool IsFilterByStore => Routes.StoreFilter != df;
        public bool IsFilterByBrand => Routes.BrandFilter != df;
        public bool IsFilterByCategory => Routes.CategoryFilter != df;
        public bool IsFilterByPrice => Routes.PriceFilter != df;

        //Sort flags
        public bool IsSortByBrand => Routes.SortField.EqualsNoCase(nameof(Brand));
        public bool IsSortByCategory => Routes.SortField.EqualsNoCase(nameof(Category));
        public bool IsSortByPrice => Routes.SortField.EqualsNoCase(nameof(Product.Price));
    }
}
