using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seunghoon_Lee_P1.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DataLayer.SeedData
{
    public class SeedStates : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasData(
                new State { StateId = "OH", Name = "Ohio" },
                new State { StateId = "MI", Name = "Michigan" },
                new State { StateId = "IN", Name = "Indiana" },
                new State { StateId = "KY", Name = "Kentucky" },
                new State { StateId = "WV", Name = "West Virginia" },
                new State { StateId = "VA", Name = "Virginia" },
                new State { StateId = "PA", Name = "Pennsylvania" },
                new State { StateId = "NY", Name = "New York" },
                new State { StateId = "NJ", Name = "New Jersey" },
                new State { StateId = "MD", Name = "Maryland" }
                );
        }
    }
}
