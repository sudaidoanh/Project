using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public String Name { get; set; }
        public String TypeDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public String TypeUser { get; set; }
        public int? UserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? DistributorId { get; set; }

    }
}
