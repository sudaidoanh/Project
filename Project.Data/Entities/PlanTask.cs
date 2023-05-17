using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class PlanTask
    {
        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
