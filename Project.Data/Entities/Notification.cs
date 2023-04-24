using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid Receivers { get; set; }
        public String Header { get; set; }
        public String Content { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public AppUser AppUser { get; set; }

    }
}
