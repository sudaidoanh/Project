using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class TaskDetail
    {
        public int Id { get; set; }
        public int IdTask { get; set; }
        public Status Status { get; set; }
        public String Description { get; set; }
        public int Rating { get; set; }
        public String Comment { get; set; }
        public Guid UserComment { get; set; }
        public Task Task { get; set; }
    }
}
