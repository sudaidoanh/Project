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
        public Guid UserCreate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public List<Surveyed> Surveyeds { get;}
        public int QuestionnaireId { get; set; }

    }
}
