using Project.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionnaireStatus Status { get; set; }
        public Guid UserCreated { get; set; }
        public int GroupId { get; set; }
    }
}
