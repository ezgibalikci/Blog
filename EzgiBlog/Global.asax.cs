using Autofac;
using Autofac.Integration.Mvc;
using EzgiBlog.Service.Singles;
using EzgiBlog.Services.Comments;
using EzgiBlog.Services.Posts;
using EzgiBlog.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EzgiBlog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<PostService>().As<IPostService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<SingleService>().As<ISingleService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EzgiBlog.Data.Models.EntityFramework.EzgiBlogDbEntities>().As<EzgiBlog.Data.Models.EntityFramework.EzgiBlogDbEntities>();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


    }
}
