using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Noftication
{
    public class AddNotificationRequest
    {
        public Guid SenderID { get; set; }
        public List<Guid> Receivers { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
