using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using StackOverflow.Data;
using StackoverFlow.Web.Models;
using StackOverflow.Data;
using StackOverFlow.Domain.Entities;

namespace StackoverFlow.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View(new AccountRegisterModel ());
        }

        [HttpPost]
        public ActionResult Register(AccountRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AutoMapper.Mapper.CreateMap<Account, AccountRegisterModel>().ReverseMap();
                Account newAccount = AutoMapper.Mapper.Map<AccountRegisterModel, Account>(model);
                var context = new StackOverflowContext();
                context.Accounts.Add(newAccount);
                context.SaveChanges();
                return RedirectToAction("login");
            }
            return View(model);
        }

        public ActionResult login(AccountLoginModel model)
        {
            var context = new StackOverflowContext();
            var account = context.Accounts.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (account != null)
            {
                FormsAuthentication.SetAuthCookie(account.Id.ToString(), false);
                return RedirectToAction("Index", "Question");
            }
            
            return View(new AccountLoginModel());
            
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }

        public ActionResult ForgotPassword()
        {

            return View("ForgotPassword");
        }
    }
}
