using Microsoft.AspNetCore.Http;
using Seunghoon_Lee_P1.Models.DTOs;
using Seunghoon_Lee_P1.Models.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Models.Grid
{
    public class GridBuilder
    {
        private const string RouteKey = "currentroute";
        public RouteDictionary Routes { get; set; }
        public ISession Session { get; set; }

        public GridBuilder(ISession p_session)
        {
            Session = p_session;
            Routes = Session.GetObject<RouteDictionary>(RouteKey) ?? new RouteDictionary();
        }
        public GridBuilder(ISession p_session, GridDTO p_griddto, string defaultSortField)
        {
            Session = p_session;
            Routes = new RouteDictionary();
            Routes.PageNumber = p_griddto.PageNumber;
            Routes.PageSize = p_griddto.PageSize;
            Routes.SortField = p_griddto.SortField ?? defaultSortField;
            Routes.SortDirection = p_griddto.SortDirection;

            SaveRouteSegment();
        }

        public void SaveRouteSegment() =>
            Session.SetObject<RouteDictionary>(RouteKey, Routes);

        public int GetTotalPages(int count)
        {
            int size = Routes.PageSize;
            return (count + size - 1) / size;
        }

        public RouteDictionary CurrentRoute => Routes;
    }
}
