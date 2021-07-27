using Seunghoon_Lee_P1.Models.DomainModels;
using Seunghoon_Lee_P1.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.ViewModels
{
    public class StoreListViewModel
    {
        public IEnumerable<Store> Stores { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
