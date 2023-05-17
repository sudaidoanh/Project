using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Plan
{
    public class PlanViewModel
    {
        public string Title { get; set; }
        public DateTime Calendar { get; set; }
        public PlanStatus PlanStatus { get; set; }
        public int DistributorId { get; set; }
        public string Purpose { get; set; }
        public string TypeDate { get; set; }
        public Guid UserId { get; set; }
        public List<Guid> Invited { get; set; }

    }
}
