using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer.SeedData
{
    public class SeedStores : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(
                new Store { StoreId = 1, Name = "LCG Ohio", Email = "ecordingly2@netscape.com", PhoneNumber = "330-769-3729", Street = "068 Village Crossing", City = "Warren", StateId = "OH" },
                new Store { StoreId = 2, Name = "LCG Michigan", Email = "abreem4@mashable.com", PhoneNumber = "734-610-3688", Street = "6313 Prentice Hill", City = "Detroit", StateId = "MI" },
                new Store { StoreId = 3, Name = "LCG Indiana", Email = "lknewstub1@yandex.ru", PhoneNumber = "317-881-7684", Street = "4729 Boyd Court", City = "Indianapolis", StateId = "IN" }
                );
        }
    }
}
