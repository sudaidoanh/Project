using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Guid Manager { get; set; }
        public Status Status { get; set; }
        public AppUser AppUser { get; set; }

    }
}
