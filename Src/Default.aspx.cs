using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Data;
using Data.SqlServer;
using Microsoft.Practices.Unity;

namespace RepositoryPrototype
{
	public partial class _Default : Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string nameValueConfigurationElement = Configuration.EnvironmentConfigurationSection.GetSection().Settings["type"].Value;
			var users = GetUsers();
			grvUsers.DataSource = users;
			grvUsers.DataBind();
		}

		private IEnumerable<User> GetUsers()
		{
			var userRep = DependencyResolver.Get<IUserRepository>();

			UserMapper mapper = new UserMapper();
			mapper.GetAllUsers();

			return userRep.FindAll();
		}
	}
}