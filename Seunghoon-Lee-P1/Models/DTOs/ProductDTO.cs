using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DTOs
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Dictionary<int, string> Stores { get; set; }
        public void Load(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Price = product.Price;
            Stores = new Dictionary<int, string>();
            foreach(Inventory i in product.Inventories)
            {
                Stores.Add(i.StoreId, i.Store.Name);
            }

        }
    }
}
