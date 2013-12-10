using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;

namespace RepositoryPrototype
{
	public class DependencyResolver
	{
		private static IUnityContainer _container;

		public static void SetResolver(IUnityContainer resolver) //Change to interface...
		{
			_container = resolver;
		}

		public static T Get<T>()
		{
			return _container.Resolve<T>();
		}

		public static T Get<T>(string name)
		{
			return _container.Resolve<T>(name);
		}

		public static void BuildUp(object item)
		{
			_container.BuildUp(item.GetType(), item);
		}

		public static IUnityContainer Resolver { get { return _container; } }
	}
}