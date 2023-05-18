using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ViewModels.Catalog.Survey
{
    public class SurveyViewModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public Guid UserCreate { get; set; }
        public String FromDate { get; set; }
        public String ToDate { get; set; }
        public int QuestionnaireId { get; set; }
        public int Total { get; set; }
        public int TotalCompleted { get; set; }

    }
}
