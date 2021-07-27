using Newtonsoft.Json;
using Seunghoon_Lee_P1.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DomainModels
{
    public class LineItem
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public double SubTotal => Product.Price * Quantity;

    }
}
