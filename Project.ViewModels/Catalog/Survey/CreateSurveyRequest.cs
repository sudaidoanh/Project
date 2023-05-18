using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Survey
{
    public class CreateSurveyRequest
    {
        public String Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int QuestionnaireId { get; set; }
        public List<ListPeopleSurveyBase> People { get; set; }
    }
}
