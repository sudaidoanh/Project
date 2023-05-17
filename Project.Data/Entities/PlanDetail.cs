using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class PlanDetail
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public Guid Invited { get; set; }
        public RequestStatus Status { get; set; }
        public Plan Plan { get; set; }
    }
}
