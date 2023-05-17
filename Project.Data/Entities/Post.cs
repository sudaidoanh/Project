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
        public Guid UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Hypertext { get; set; }
        public string Content { get; set; }
        public ArticleStatus Status { get; set; }
        public List<PostImage> PostImages { get; set; }
    }
}
