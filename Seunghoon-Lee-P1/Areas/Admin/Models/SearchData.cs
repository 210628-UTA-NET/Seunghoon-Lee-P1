using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Seunghoon_Lee_P1.Models.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seunghoon_Lee_P1.Areas.Admin.Models
{
    public class SearchData
    {
        private const string SearchKey = "search";
        private const string TypeKey = "searchtype";
        private ITempDataDictionary tempData { get; set; }
        public SearchData(ITempDataDictionary temp) => tempData = temp;
 
        public string SearchTerm
        {
            get => tempData.Peek(SearchKey)?.ToString();
            set => tempData[SearchKey] = value;
        }

        public string Type
        {
            get => tempData.Peek(TypeKey)?.ToString();
            set => tempData[TypeKey] = value;
        }

        public bool HasSearchTerm => !string.IsNullOrEmpty(SearchTerm);
        public bool IsProduct => Type.EqualsNoCase("product");
        public bool IsStore => Type.EqualsNoCase("store");
        public bool IsUser => Type.EqualsNoCase("user");

        public void Clear()
        {
            tempData.Remove(SearchKey);
            tempData.Remove(TypeKey);
        }
    }
}
