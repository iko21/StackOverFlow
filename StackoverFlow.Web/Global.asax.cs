using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using AutoMapper;
using StackoverFlow.Web.Models;
using StackOverflow.Data;
using StackOverFlow.Domain.Entities;

namespace StackoverFlow.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoFacConfig.Register();
        }
    }

    public static class AutoFacConfig
    {
        public static IContainer Container;
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => Mapper.Engine).As<IMappingEngine>();
            builder.Register(c => new StackOverflowContext()).As<StackOverflowContext>();
            Container = builder.Build();
        }
    }

    public static class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<AccountRegisterModel, Account>().ReverseMap();
            Mapper.CreateMap<Question, QuestionListModel>().ReverseMap();
        }
    }
}
