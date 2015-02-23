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
        }
    }

    public static class AutoFacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.Register(c => Mapper.Engine).As<IMappingEngine>();
            var container = builder.Build();
        }
    }

    public static class AutoMapperConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<AccountRegisterModel, Account>().ReverseMap();
        }
    }
}
