using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class SubmitedSurveyedAnswer
    {
        public int SubmitedSurveyedId { get; set; }
        public SubmitedSurveyed SubmitedSurveyed { get; set; }
        public int QuestionnaireDetailId { get; set; }
        public QuestionnaireDetail QuestionnaireDetail { get; set; }
        public string Answer { get; set; }

    }
}
