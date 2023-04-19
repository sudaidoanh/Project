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
        public int? UserId { get; set; }
        public int? DeviceId { get; set; }

    }
}
