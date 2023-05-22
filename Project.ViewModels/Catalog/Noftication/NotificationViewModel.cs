using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Noftication
{
    public class NotificationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid SenderId { get; set; }
        public string SenderName { get; set; }
        public Guid Receiver { get; set; }
        public Status Status { get; set; }
    }
}
