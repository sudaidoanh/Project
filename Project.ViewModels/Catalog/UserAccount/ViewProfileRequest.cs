using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.UserAccount
{
    public class ViewProfileRequest
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }

    }
}
