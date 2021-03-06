using Seunghoon_Lee_P1.Models.DTOs;
using Seunghoon_Lee_P1.Models.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.Grid
{
    public class RouteDictionary : Dictionary<string, string>
    {
        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }
        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }
        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }
        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;
            if (current.SortField.EqualsNoCase(fieldName) && current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "desc";
            else
                this[nameof(GridDTO.SortDirection)] = "asc";
        }

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach(var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }

        public string BrandFilter
        {
            get => Get(nameof(ProductGridDTO.Brand))?.Replace(FilterPrefix.Brand, "");
            set => this[nameof(ProductGridDTO.Brand)] = value;
        }
        public string CategoryFilter
        {
            get => Get(nameof(ProductGridDTO.Category))?.Replace(FilterPrefix.Category, "");
            set => this[nameof(ProductGridDTO.Category)] = value;
        }
        public string PriceFilter
        {
            get => Get(nameof(ProductGridDTO.Price))?.Replace(FilterPrefix.Price, "");
            set => this[nameof(ProductGridDTO.Price)] = value;
        }
        public string StoreFilter
        {
            //get => Get(nameof(ProductGridDTO.Store))?.Replace(FilterPrefix.Store, "");
            //store filter contains prefix, id, and slug (eg, store-8-lcg-ohio)
            get
            {
                string s = Get(nameof(ProductGridDTO.Store))?.Replace(FilterPrefix.Store, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(ProductGridDTO.Store)] = value;
        }

        public void ClearFilters() => BrandFilter = CategoryFilter = PriceFilter = StoreFilter = ProductGridDTO.DefaultFilter;
    }
}
