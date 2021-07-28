using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Areas.Admin.Models
{
    public class SearchViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        [Required(ErrorMessage = "Please enter a search term")]
        public string SearchTerm { get; set; }
        public string Type { get; set; }
        public string Header { get; set; }
    }
}
