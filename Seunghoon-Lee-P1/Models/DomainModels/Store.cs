using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DomainModels
{
    public class Store
    {
        public int StoreId { get; set; }
        [Required(ErrorMessage = "Please enter store name")]
        [MaxLength(40)] 
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [MaxLength(40)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter phone number")]
        [MaxLength(40)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter street name")]
        [MaxLength(40)]
        public string Street { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        [MaxLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "Please select state")]
        [MaxLength(40)]
        public string StateId { get; set; }

        public State State { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}
