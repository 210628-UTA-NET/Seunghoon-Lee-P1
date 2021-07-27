using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer.SeedData
{
    public class SeedProducts : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new { ProductId = 1, Name = "Les Paul Standard", BrandId = 2, CategoryId = 1, Price = 2499.99},
                new { ProductId = 2, Name = "Les Paul Classic", BrandId = 2, CategoryId = 1, Price = 1999.99},
                new { ProductId = 3, Name = "American Professional Stratocaster", BrandId = 1, CategoryId = 1, Price = 1499.99},
                new { ProductId = 4, Name = "Player Stratocaster", BrandId = 1, CategoryId = 1, Price = 749.99},
                new { ProductId = 5, Name = "SE Custom 24", BrandId = 3, CategoryId = 1, Price = 899.99},
                new { ProductId = 6, Name = "Premium S1070PBZ", BrandId = 4, CategoryId = 1, Price = 1399.99},
                new { ProductId = 7, Name = "Affinity Series Stratocaster HH", BrandId = 5, CategoryId = 1, Price = 249.99},
                new { ProductId = 8, Name = "D-28 Standard Dreadnought", BrandId = 6, CategoryId = 4, Price = 2999.99},
                new { ProductId = 9, Name = "314ce-K Special Edition", BrandId = 7, CategoryId = 4, Price = 2799.99},
                new { ProductId = 10, Name = "G2420T Streamliner Single Cutaway", BrandId = 8, CategoryId = 2, Price = 549.99},
                new { ProductId = 11, Name = "Casino", BrandId = 10, CategoryId = 2, Price = 649.99},
                new { ProductId = 12, Name = "CE 24", BrandId = 3, CategoryId = 3, Price = 2239.99},
                new { ProductId = 13, Name = "C40", BrandId = 9, CategoryId = 5, Price = 149.99},
                new { ProductId = 14, Name = "Academy 12e-N Grand Concert", BrandId = 7, CategoryId = 5, Price = 799.99},
                new { ProductId = 15, Name = "Nylon String Silent", BrandId = 9, CategoryId = 5, Price = 699.99},
                new { ProductId = 16, Name = "CC-60S Concert", BrandId = 1, CategoryId = 4, Price = 219.99},
                new { ProductId = 17, Name = "2004 SRV Number 1 Tribute", BrandId = 1, CategoryId = 1, Price = 46999.99},
                new { ProductId = 18, Name = "SG Traditional Pro", BrandId = 10, CategoryId = 1, Price = 449.99},
                new { ProductId = 19, Name = "Les Paul Studio", BrandId = 2, CategoryId = 1, Price = 1499.99},
                new { ProductId = 20, Name = "Player Telecaster Maple Fingerboard", BrandId = 1, CategoryId = 1, Price = 749.99}
                );
        }
    }
}
