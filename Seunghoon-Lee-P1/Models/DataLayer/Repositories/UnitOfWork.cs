using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //Pass db context
        private P1Context context;
        public UnitOfWork(P1Context p_context)
        {
            context = p_context;
        }

        private Repository<Product> productData;
        public Repository<Product> Products
        {
            get
            {
                if (productData == null)
                    productData = new Repository<Product>(context);
                return productData;
            }
        }

        private Repository<Brand> brandData;
        public Repository<Brand> Brands
        {
            get
            {
                if (brandData == null)
                    brandData = new Repository<Brand>(context);
                return brandData;
            }
        }

        private Repository<Category> categoryData;
        public Repository<Category> Categories
        {
            get
            {
                if (categoryData == null)
                    categoryData = new Repository<Category>(context);
                return categoryData;
            }
        }

        private Repository<Store> storeData;
        public Repository<Store> Stores
        {
            get
            {
                if (storeData == null)
                    storeData = new Repository<Store>(context);
                return storeData;
            }
        }

        private Repository<State> stateData;
        public Repository<State> States
        {
            get
            {
                if (stateData == null)
                    stateData = new Repository<State>(context);
                return stateData;
            }
        }

        private Repository<Inventory> inventoryData;
        public Repository<Inventory> Inventories
        {
            get
            {
                if (inventoryData == null)
                    inventoryData = new Repository<Inventory>(context);
                return inventoryData;
            }
        }

        public void AddNewInventories(Product product, int[] storeids)
        {
            product.Inventories = storeids.Select(i => new Inventory { Product = product, StoreId = i }).ToList();
        }

        public void DeleteCurrentInventories(Product product)
        {
            var currentStores = Inventories.List(new QueryOptions<Inventory>
            {
                Where = i => i.ProductId == product.ProductId
            });
            foreach(Inventory i in currentStores)
            {
                Inventories.Delete(i);
            }
        }

        public void Save() => context.SaveChanges();
    }
}
