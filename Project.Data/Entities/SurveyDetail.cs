using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class SurveyDetail
    {
        public int Id { get; set; }
        public int? SurveyId { get; set; }
        public String Question { get; set; }
        public String Answers { get; set; }
        public Survey Survey { get; set; }
    }
}
