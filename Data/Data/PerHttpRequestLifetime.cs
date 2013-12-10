// -----------------------------------------------------------------------
// <copyright file="PerHttpRequestLifetime" company="SAXO BANK">
//     Saxo Bank A/S All Rights reserved 
// </copyright>
// <author>SMI</author>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Practices.Unity;

namespace Data
{
	public class PerHttpRequestLifetime : LifetimeManager
	{
		private readonly Guid key = Guid.NewGuid();

		public override object GetValue()
		{
			return HttpContext.Current.Items[key];
		}

		public override void SetValue(object newValue)
		{
			HttpContext.Current.Items[key] = newValue;
		}

		public override void RemoveValue()
		{
			var obj = GetValue();
			HttpContext.Current.Items.Remove(obj);
		}
	}
}
