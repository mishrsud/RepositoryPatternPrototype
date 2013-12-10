using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Data;
using Data.SqlServer;
using Microsoft.Practices.Unity;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using RepositoryPrototype;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace RepositoryPrototype
{
	public class Global : HttpApplication
	{
		public static UnityContainer Container;

		void Application_Start(object sender, EventArgs e)
		{
			SetupDependencyInjection();
			// Code that runs on application startup
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AuthConfig.RegisterOpenAuth();
			RouteConfig.RegisterRoutes(RouteTable.Routes);
		}

		private void SetupDependencyInjection()
		{
			Container = new UnityContainer();
			Container.AddExtension(new Data.SqlServer.Module());
			//Container.RegisterType<UserMapper>("userMapper",new InjectionConstructor(new ResolvedParameter(typeof (IUserRepository),"SqlServer")));
			//Container.Configure<Interception>()
			//			.AddPolicy("log-app-start")
			//			.AddMatchingRule<MemberNameMatchingRule>(new InjectionConstructor("",true))
			//			.AddCallHandler<AppStartHandler>()
			DependencyResolver.SetResolver(Container);
		}

		void Application_End(object sender, EventArgs e)
		{
			//  Code that runs on application shutdown

		}

		void Application_Error(object sender, EventArgs e)
		{
			// Code that runs when an unhandled error occurs

		}
	}
}
