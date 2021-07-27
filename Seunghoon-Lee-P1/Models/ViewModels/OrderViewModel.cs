using Seunghoon_Lee_P1.Models.DomainModels;
using Seunghoon_Lee_P1.Models.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.ViewModels
{
    public class OrderViewModel
    {
        public IEnumerable<LineItem> LineItems { get; set; }
        public double SubTotal { get; set; }
        public RouteDictionary ProductGridRoute { get; set; }
    }
}
