using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Area
{
    public class GetAreaPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; } 
    }
}
