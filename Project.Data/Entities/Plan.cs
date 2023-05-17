using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public String TypeDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public DateTime Calendar { get; set; }
        public string Purpose { get; set; }
        public int DistributorId { get; set; }
        public PlanStatus PlanStatus { get; set; }
        public List<PlanDetail> PlanDetails { get; set; }
        public List<PlanTask> PlanTasks { get; set; }

    }
}
