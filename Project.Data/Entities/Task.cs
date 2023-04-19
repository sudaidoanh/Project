using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int UserAskTaskId { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public Plan Plan { get; set; }

    }
}
