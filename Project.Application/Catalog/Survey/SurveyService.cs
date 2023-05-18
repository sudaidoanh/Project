using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.Data.EF;
using Project.Data.Entities;
using Project.Data.Enums;
using Project.ViewModels.Catalog.Survey;
using Project.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Catalog.Survey
{
    public class SurveyService : ISurveyService
    {
        private readonly ProjectDbContext _context;
        private readonly IConfiguration _config;
        public SurveyService(ProjectDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public async Task<bool> CreateQuestionnaire(Guid userCreated, AddQuestionnaireRequest request)
        {
            var questionnaire = new Questionnaire()
            {
                UserCreated = userCreated,
                Title = request.Title,
                Status = Data.Enums.QuestionnaireStatus.Disable,
                GroupId = request.subgroup ? 1 : 0,
            };
            await _context.Questionnaires.AddAsync(questionnaire);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ResultModel<QuestionnaireViewModel>> GetQuestionnaire(Guid userCreate, GetQuestionnairePagingRequest request)
        {
            var query = from q in _context.Questionnaires.Where( q => q.UserCreated.Equals(userCreate) ) 
                        select q;
            if (!string.IsNullOrEmpty(request.keyword)) query = query.Where(x => x.Title.Contains(request.keyword));

            int totalRow = await query.CountAsync();

            var data = query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new QuestionnaireViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    UserCreated = x.UserCreated,
                    Status = x.Status == Data.Enums.QuestionnaireStatus.Available? "Available" : "Disable",
                }).ToListAsync();
            return new ResultModel<QuestionnaireViewModel>()
            {
                TotalRecord = totalRow,
                Items = await data
            };
        }


        public async Task<int> EditQuestionnaire(int questionnaireId, EditQuestionRequest request)
        {
            var questionnaire = await _context.Questionnaires.FindAsync(questionnaireId);
            if (questionnaire == null)
            {
                return 0;
            }
            foreach (var x in request.questionBases)
            {
                var answers = "";
                foreach(var y in x.Answer)
                {
                    answers += "; " + y;
                }
                var questionnaireDetail = new QuestionnaireDetail()
                {
                    QuestionnaireId = questionnaireId,
                    Question = x.Question,
                    Answers = answers,
                    TypeAnswer = AnswerType.Radio.Equals(x.AnswerType) ? "Radio" : "Checkbox",
                };
                await _context.QuestionnaireDetails.AddAsync(questionnaireDetail);
            }

            questionnaire.GroupId = request.subgroup;
            _context.Questionnaires.Update(questionnaire);
            
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> EditQuestion(int questionnaireDetailId, QuestionBase request)
        {
            var answers = "";
            foreach (var y in request.Answer)
            {
                answers += "; " + y;
            }
            var question = await _context.QuestionnaireDetails.FindAsync(questionnaireDetailId);
            question.Question = request.Question;
            question.Answers = answers;
            question.TypeAnswer = AnswerType.Radio.Equals(request.AnswerType) ? "Radio" : "Checkbox";
            _context.QuestionnaireDetails.Update(question);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ResultModel<SurveyViewModel>> getSurvey(Guid userCreated)
        {
            var query = from s in _context.Surveys.Where( s => s.UserCreate.Equals(userCreated))
                        select s;
            var totalRecord = await query.CountAsync();
            var data = query.Select(x => new SurveyViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                FromDate = x.FromDate.ToShortDateString(),
                ToDate = x.ToDate.ToShortDateString(),
                Total =  _context.Surveyeds.Where(c => c.SurveyId == x.Id).Count(),
                TotalCompleted = _context.Surveyeds.Where(c => c.SurveyId == x.Id && c.Status.Equals(Status.Active)).Count(),
                QuestionnaireId = x.QuestionnaireId
            }).ToListAsync();
            return new ResultModel<SurveyViewModel>()
            {
                TotalRecord = totalRecord,
                Items = await data,
            };
        }



        public async Task<int> CreateSurvey(Guid userCreated, CreateSurveyRequest request)
        {
           /* var smtpClient = new SmtpClient(_config["Smtp:Host"])
            {
                Port = int.Parse(_config["Smtp:Port"]),
                Credentials = new NetworkCredential(_config["Smtp:Username"], _config["Smtp:Password"]),
                EnableSsl = true,
            };
            smtpClient.UseDefaultCredentials = false;*/
            var surveyid = CreateNewSurvey(userCreated, request);
            foreach(var x in request.People)
            {
                var suveyed = new Surveyed()
                {
                    PerformerName = x.Name,
                    Email = x.Email,
                    Status = Status.InActive,
                    SurveyId = await surveyid,
                };
                await _context.Surveyeds.AddAsync(suveyed);

                /*var mailMessage = new MailMessage
                {
                    From = new MailAddress("sudoanh11@gmail.com"),
                    Subject = "We invite you to take the survey",
                    Body = "<h1>Hello</h1>",
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(x.Email);

                smtpClient.Send(mailMessage);*/
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CreateNewSurvey(Guid userCreated, CreateSurveyRequest request)
        {
            var survey = new Data.Entities.Survey()
            {
                Title = request.Title,
                UserCreate = userCreated,
                CreatedDate = DateTime.Now,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                QuestionnaireId = request.QuestionnaireId,
            };
            await _context.Surveys.AddAsync(survey);
            await _context.SaveChangesAsync();
            return survey.Id;
        }
    }
}
