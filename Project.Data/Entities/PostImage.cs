using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class PostImage
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string ImagePath { get; set; }
        public bool CurrentSet { get; set; }
        public DateTime DateCreated { get; set; }
        public int SortOder { get; set; }
        public long FileSize { get; set; }
        public Post Post{ get; set; }
    }
}
