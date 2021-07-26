using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DomainModels
{
    public class State
    {
        [MaxLength(2)]
        public string StateId { get; set; }
        [MaxLength(40)]
        public string Name { get; set; }

        public ICollection<Store> Stores { get; set; }
    }
}
