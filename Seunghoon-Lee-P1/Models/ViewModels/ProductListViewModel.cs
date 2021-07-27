using Seunghoon_Lee_P1.Models.DomainModels;
using Seunghoon_Lee_P1.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<Store> Stores { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public Dictionary<string, string> Prices =>
            new Dictionary<string, string>
            {
                {"under500", "$0 - $500" },
                {"500to1000", "$500 - $1000" },
                {"over1000", "$1000 - $50000" }
            };
        public int[] PageSizes => new int[] { 5, 10, 20, 40};
    }
}
