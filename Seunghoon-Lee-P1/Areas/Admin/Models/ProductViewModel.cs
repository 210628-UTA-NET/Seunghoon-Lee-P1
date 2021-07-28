using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Seunghoon_Lee_P1.Models.DomainModels;

namespace Seunghoon_Lee_P1.Areas.Admin.Models
{
    public class ProductViewModel : IValidatableObject
    {
        public Product Product { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Store> Stores { get; set; }
        public int[] SelectedStores { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SelectedStores == null)
            {
                yield return new ValidationResult(
                  "Please select at least one store",
                  new[] { nameof(SelectedStores) });
            }
        }
    }
}
