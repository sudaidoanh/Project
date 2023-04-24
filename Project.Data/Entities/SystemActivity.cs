using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class SystemActivity
    {
        public int Id { get; set; }
        public String ActionName { get; set; }
        public DateTime ActionDate { get; set; }
        public String ClientIP { get; set; }
        public Guid UserId { get; set; }
        public string Device { get; set; }
        public AppUser AppUser { get; set; }

    }
}
