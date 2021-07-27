using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer.SeedData
{
    public class SeedInventories : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.HasData(
                new { StoreId = 1, ProductId = 1, Quantity = 5 },
                new { StoreId = 1, ProductId = 2, Quantity = 4 },
                new { StoreId = 1, ProductId = 3, Quantity = 2 },
                new { StoreId = 1, ProductId = 4, Quantity = 4 },
                new { StoreId = 1, ProductId = 5, Quantity = 6 },
                new { StoreId = 1, ProductId = 6, Quantity = 7 },
                new { StoreId = 1, ProductId = 7, Quantity = 8 },
                new { StoreId = 1, ProductId = 8, Quantity = 6 },
                new { StoreId = 1, ProductId = 9, Quantity = 9 },
                new { StoreId = 1, ProductId = 10, Quantity = 1 },
                new { StoreId = 1, ProductId = 11, Quantity = 4 },
                new { StoreId = 1, ProductId = 12, Quantity = 3 },
                new { StoreId = 1, ProductId = 13, Quantity = 10 },
                new { StoreId = 1, ProductId = 14, Quantity = 9 },
                new { StoreId = 1, ProductId = 15, Quantity = 10 },
                new { StoreId = 1, ProductId = 16, Quantity = 6 },
                new { StoreId = 1, ProductId = 17, Quantity = 2 },
                new { StoreId = 1, ProductId = 18, Quantity = 1 },
                new { StoreId = 1, ProductId = 19, Quantity = 5 },
                new { StoreId = 1, ProductId = 20, Quantity = 8 },
                new { StoreId = 2, ProductId = 1, Quantity = 4 },
                new { StoreId = 2, ProductId = 2, Quantity = 1 },
                new { StoreId = 2, ProductId = 3, Quantity = 7 },
                new { StoreId = 2, ProductId = 4, Quantity = 4 },
                new { StoreId = 2, ProductId = 5, Quantity = 3 },
                new { StoreId = 2, ProductId = 6, Quantity = 1 },
                new { StoreId = 2, ProductId = 7, Quantity = 3 },
                new { StoreId = 2, ProductId = 8, Quantity = 1 },
                new { StoreId = 2, ProductId = 9, Quantity = 2 },
                new { StoreId = 2, ProductId = 10, Quantity = 8 },
                new { StoreId = 2, ProductId = 11, Quantity = 7 },
                new { StoreId = 2, ProductId = 12, Quantity = 5 },
                new { StoreId = 2, ProductId = 13, Quantity = 6 },
                new { StoreId = 2, ProductId = 14, Quantity = 1 },
                new { StoreId = 2, ProductId = 15, Quantity = 8 },
                new { StoreId = 2, ProductId = 16, Quantity = 5 },
                new { StoreId = 2, ProductId = 17, Quantity = 1 },
                new { StoreId = 2, ProductId = 18, Quantity = 6 },
                new { StoreId = 2, ProductId = 19, Quantity = 10 },
                new { StoreId = 2, ProductId = 20, Quantity = 1 },
                new { StoreId = 3, ProductId = 1, Quantity = 4 },
                new { StoreId = 3, ProductId = 2, Quantity = 1 },
                new { StoreId = 3, ProductId = 3, Quantity = 6 },
                new { StoreId = 3, ProductId = 4, Quantity = 8 },
                new { StoreId = 3, ProductId = 5, Quantity = 2 },
                new { StoreId = 3, ProductId = 6, Quantity = 1 },
                new { StoreId = 3, ProductId = 7, Quantity = 7 },
                new { StoreId = 3, ProductId = 8, Quantity = 8 },
                new { StoreId = 3, ProductId = 9, Quantity = 4 },
                new { StoreId = 3, ProductId = 10, Quantity = 1 },
                new { StoreId = 3, ProductId = 11, Quantity = 8 },
                new { StoreId = 3, ProductId = 12, Quantity = 3 },
                new { StoreId = 3, ProductId = 13, Quantity = 1 },
                new { StoreId = 3, ProductId = 14, Quantity = 3 },
                new { StoreId = 3, ProductId = 15, Quantity = 8 },
                new { StoreId = 3, ProductId = 16, Quantity = 9 },
                new { StoreId = 3, ProductId = 17, Quantity = 1 },
                new { StoreId = 3, ProductId = 18, Quantity = 9 },
                new { StoreId = 3, ProductId = 19, Quantity = 7 },
                new { StoreId = 3, ProductId = 20, Quantity = 5 }
                );
        }
    }
}
