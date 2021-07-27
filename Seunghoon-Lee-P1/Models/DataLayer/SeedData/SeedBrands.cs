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
                new Brand { BrandId = "FD", Name = "Fender" },
                new Brand { BrandId = "GS", Name = "Gibson" },
                new Brand { BrandId = "PR", Name = "PRS" },
                new Brand { BrandId = "IB", Name = "Ibanez" },
                new Brand { BrandId = "SQ", Name = "Squire" },
                new Brand { BrandId = "MT", Name = "Martin" },
                new Brand { BrandId = "TL", Name = "Taylor" },
                new Brand { BrandId = "GR", Name = "Gretch" },
                new Brand { BrandId = "YM", Name = "Yamaha" },
                new Brand { BrandId = "EP", Name = "Epiphone"}
                );
        }
    }
}
