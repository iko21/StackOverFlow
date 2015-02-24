using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Autofac;
using StackoverFlow.Web.Models;
using StackOverflow.Data;
using StackOverFlow.Domain.Entities;

namespace StackoverFlow.Web.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        //
        // GET: /Question/
    [AllowAnonymous]
        public ActionResult Index()
        {

            var context3 = AutoFacConfig.Container.Resolve<StackOverflowContext>();
            var entities = context3.Questions.ToList();
            AutoMapper.Mapper.CreateMap<Question, QuestionListModel>().ReverseMap();
            List<QuestionListModel> models = new List<QuestionListModel>();

        foreach (var question in entities)
        {
            QuestionListModel MODELtEST = AutoMapper.Mapper.Map<Question, QuestionListModel>(question);
            Account owner = context3.Accounts.Find(question.OwnerId);
            MODELtEST.OwnerName = owner.Name;
            models.Add(MODELtEST);
        }
        
            return View(models);
        }

        public ActionResult Question()
        {
            return View(new CreateNewQuestionModel());
        }

        [HttpPost]
        public ActionResult Question(CreateNewQuestionModel model)
        {
            if (ModelState.IsValid)
            {
                AutoMapper.Mapper.CreateMap<Question, CreateNewQuestionModel>().ReverseMap();
                Question newQuestion = AutoMapper.Mapper.Map<CreateNewQuestionModel, Question>(model);
                newQuestion.CreationDate = DateTime.Now;
                newQuestion.ModificationDate = DateTime.Now;
                newQuestion.OwnerId = Guid.Parse(HttpContext.User.Identity.Name);
                var context2 = AutoFacConfig.Container.Resolve<StackOverflowContext>();
                context2.Questions.Add(newQuestion);
                context2.SaveChanges();
                return RedirectToAction("index");
            }
            return View(model);
        }
        
	}
}