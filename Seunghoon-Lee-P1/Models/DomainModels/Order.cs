using Microsoft.AspNetCore.Http;
using Seunghoon_Lee_P1.Models.DataLayer;
using Seunghoon_Lee_P1.Models.DataLayer.Repositories;
using Seunghoon_Lee_P1.Models.DTOs;
using Seunghoon_Lee_P1.Models.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.DomainModels
{
    public class Order
    {
        private const string OrderKey = "myorder";
        private const string CountKey = "mycount";

        private List<LineItem> lineItems { get; set; }
        private List<LineItemDTO> storedItems { get; set; }

        private ISession session { get; set; }
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCooki { get; set; }

        public Order(HttpContext context)
        {
            session = context.Session;
            requestCookies = context.Request.Cookies;
            responseCooki = context.Response.Cookies;
        }

        public void Load(Repository<Product> data)
        {
            lineItems = session.GetObject<List<LineItem>>(OrderKey);

            if(lineItems == null)
            {
                lineItems = new List<LineItem>();
                storedItems = requestCookies.GetObject<List<LineItemDTO>>(OrderKey);
            }

            if (storedItems?.Count > lineItems?.Count)
            {
                foreach (LineItemDTO storedItem in storedItems)
                {
                    var product = data.Get(new QueryOptions<Product>
                    {
                        Includes = "Inventories.Store, Brand, Category",
                        Where = p => p.ProductId == storedItem.ProductId
                    });
                    if (product != null)
                    {
                        var dto = new ProductDTO();
                        dto.Load(product);
                        LineItem item = new LineItem
                        {
                            Product = dto,
                            Quantity = storedItem.Quantity
                        };
                        lineItems.Add(item);
                    }
                }
                Save();
            }
        }
    }
}
