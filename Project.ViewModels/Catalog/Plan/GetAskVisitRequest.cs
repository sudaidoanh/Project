using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Plan
{
    public class GetAskVisitRequest
    {
        public int Id { get; set; }
        public DateTime Calendar { get; set; }
        public int DistributorId { get; set; }
        public string Purpose { get; set; }
        public string TypeDate { get; set; }
        public Guid UserAsk { get; set; }
    }
}
