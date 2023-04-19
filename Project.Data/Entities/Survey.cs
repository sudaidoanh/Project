using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Survey
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public int? UserCreate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
