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
        public Guid UserId { get; set; }
        public Guid UserAskTaskId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<TaskDetail> TaskDetails { get; set; }
        public List<MediaTask> MediaTasks { get; set; }
        public List<PlanTask> PlanTasks { get; set; }
    }
}
