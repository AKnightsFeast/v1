using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Optimization;

using web.Models;
using web.Models.Enums;
using web.Models.Binders;

namespace web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Scripts.DefaultTagFormat = @"<script src=""{0}"" type=""text/javascript""></script>";

            AreaRegistration.RegisterAllAreas();

            AuthConfig.RegisterAuth();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters, this.Context.IsDebuggingEnabled);

            ModelBinders.Binders.Add(typeof(BeefPrepType), new EnumModelBinder<BeefPrepType>());
            ModelBinders.Binders.Add(typeof(ChickenPrepType), new EnumModelBinder<ChickenPrepType>());
            ModelBinders.Binders.Add(typeof(ContainerType), new EnumModelBinder<ContainerType>());
            ModelBinders.Binders.Add(typeof(PackageType), new EnumModelBinder<PackageType>());
            ModelBinders.Binders.Add(typeof(SpiceType), new EnumModelBinder<SpiceType>());
            ModelBinders.Binders.Add(typeof(PetLocation), new EnumModelBinder<PetLocation>());
            ModelBinders.Binders.Add(typeof(GiftCertificateDestination), new EnumModelBinder<GiftCertificateDestination>());

            States.Load();
        }
    }
}