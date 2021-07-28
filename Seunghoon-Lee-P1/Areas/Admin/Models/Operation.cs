using Seunghoon_Lee_P1.Models.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Areas.Admin.Models
{
    public static class Operation
    {
        public static bool IsAdd(string action) => action.EqualsNoCase("add");

        public static bool IsDelete(string action) => action.EqualsNoCase("delete");
    }
}
