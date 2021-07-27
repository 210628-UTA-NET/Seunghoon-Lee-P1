using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer.SeedData
{
    public class SeedBrands : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasData(
                new Brand { BrandId = 1, Name = "Fender" },
                new Brand { BrandId = 2, Name = "Gibson" },
                new Brand { BrandId = 3, Name = "PRS" },
                new Brand { BrandId = 4, Name = "Ibanez" },
                new Brand { BrandId = 5, Name = "Squire" },
                new Brand { BrandId = 6, Name = "Martin" },
                new Brand { BrandId = 7, Name = "Taylor" },
                new Brand { BrandId = 8, Name = "Gretch" },
                new Brand { BrandId = 9, Name = "Yamaha" },
                new Brand { BrandId = 10, Name = "Epiphone"}
                );
        }
    }
}
