using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer.Repositories
{
    interface IUnitOfWork
    {
        Repository<Product> Products { get; }
        Repository<Brand> Brands { get; }
        Repository<Category> Categories { get; }
        Repository<Store> Stores { get; }
        Repository<State> States { get; }
        Repository<Inventory> Inventories { get; }

        void DeleteCurrentInventories(Product product);
        void AddNewInventories(Product product, int[] storeids);
        void Save();

    }
}
