using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer.SeedData
{
    public class SeedCategories : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new { CategoryId = "SE", Name = "Solid Body Electric Guitars" },
                new { CategoryId = "HE", Name = "Hollow Body Electric Guitars" },
                new { CategoryId = "SHE", Name = "Semi-Hollow Body Electric Guitars" },
                new { CategoryId = "A", Name = "Acoustic Guitasr" },
                new { CategoryId = "CN", Name = "Classic & Nylon guitars" }
                );
        }
    }
}
