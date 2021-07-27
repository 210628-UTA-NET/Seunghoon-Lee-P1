using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DomainModels
{
    public class Category
    {
        [Required(ErrorMessage = "Please enter category id")]
        [MaxLength(10)]
        public string CategoryId { get; set; }
        [Required(ErrorMessage = "Please enter category name")]
        [MaxLength(40)]
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
