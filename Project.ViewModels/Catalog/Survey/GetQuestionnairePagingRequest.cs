using Project.Data.Enums;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Survey
{
    public class GetQuestionnairePagingRequest : PagingRequestBase
    {
        public string keyword { get; set; }
    }
}
