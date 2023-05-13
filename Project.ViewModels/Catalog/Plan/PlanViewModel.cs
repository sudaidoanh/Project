using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Plan
{
    public class PlanViewModel
    {
        public DateTime Calendar { get; set; }
        public int DistributorId { get; set; }
        public string Purpose { get; set; }
        public string TypeDate { get; set; }
        public Guid UserId { get; set; }
        public Guid Invited { get; set; }

    }
}
