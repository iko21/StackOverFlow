using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Antlr.Runtime.Misc;
using StackoverFlow.Web.Models;

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
            List<QuestionListModel> models = new ListStack<QuestionListModel>();
            QuestionListModel MODELtEST = new QuestionListModel();
            MODELtEST.Title = "title test";
            MODELtEST.OwnerName = "Juan";
            MODELtEST.Votes = 1;
            MODELtEST.CreationDate= DateTime.Now;
            MODELtEST.OwnerId = Guid.NewGuid();
            MODELtEST.QuestionId = Guid.NewGuid();
            
            models.Add(MODELtEST);
            QuestionListModel model2 = new QuestionListModel();

            model2.Title = "title Test";
            model2.OwnerName = "Juan";
            model2.Votes = 1;
            model2.CreationDate = DateTime.Now;
            model2.OwnerId = Guid.NewGuid();
            model2.QuestionId = Guid.NewGuid();

            models.Add(model2);

            return View(models);
        }

        public ActionResult Question()
        {
            return View(new CreateNewQuestion());
        }

        
        
	}
}