using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DTOs
{
    public class ProductGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Store { get; set; } = DefaultFilter;
        public string Brand { get; set; } = DefaultFilter;
        public string Category { get; set; } = DefaultFilter;
        public string Price { get; set; } = DefaultFilter;


    }
}
