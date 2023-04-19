using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Surveyed
    {
        public int Id { get; set; }
        public int? SurveyId { get; set; }
        public int? UserId { get; set; }
        public Status Status { get; set; }

    }
}
