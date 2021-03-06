using Seunghoon_Lee_P1.Models.DomainModels;
using Seunghoon_Lee_P1.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.ExtensionMethods
{
    public static class LineItemListExtensions
    {
        public static List<LineItemDTO> ToDTO(this List<LineItem> list) =>
            list.Select(li => new LineItemDTO
            {
                ProductId = li.Product.ProductId,
                Quantity = li.Quantity
            }).ToList();
    }
}
