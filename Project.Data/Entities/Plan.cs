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
        public String TypeDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }
        public Guid Invited { get; set; }
        public DateTime Calendar { get; set; }
        public string Purpose { get; set; }
        public Status Status { get; set; }
        public int DistributorId { get; set; }

    }
}
