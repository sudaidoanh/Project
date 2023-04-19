using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class MediaTask
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public String MediaType { get; set; }
        public String SrcFile { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
