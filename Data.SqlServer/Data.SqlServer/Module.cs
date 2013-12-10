// -----------------------------------------------------------------------
// <copyright file="Module" company="SAXO BANK">
//     Saxo Bank A/S All Rights reserved 
// </copyright>
// <author>SMI</author>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Data.SqlServer
{
	public class Module : UnityContainerExtension
	{
		protected override void Initialize()
		{
			Container.RegisterType<IDbContext, DbContext>(new PerHttpRequestLifetime());
			Container.RegisterType<IUserRepository, UserRepository>(new PerHttpRequestLifetime(), new InjectionConstructor(new ResolvedParameter<IDbContext>()));
		}
	}
}
