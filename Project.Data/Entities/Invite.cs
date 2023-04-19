using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Invite
    {
        public int Id { get; set; }
        public int? PlanId { get; set; }
        public int? Inviter { get; set; }
        public int? Invited { get; set; }
        public Status Status { get; set; }
        public Plan Plan { get; set; }
    }
}
