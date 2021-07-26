using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DomainModels
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter product name")]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter price")]
        [Range(0.0, 1000000.0, ErrorMessage = "Price must be greater than 0")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Please select brand")]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Please select category")]
        public int CategoryId { get; set; }

        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
