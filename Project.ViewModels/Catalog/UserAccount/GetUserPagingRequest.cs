using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.UserAccount
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        /*public List<Guid> UserId { get; set; }*/
    }
}
