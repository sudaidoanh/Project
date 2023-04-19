using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public String Image { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Header { get; set; }
        public String Content { get; set; }
        public Status Display { get; set; }

    }
}
