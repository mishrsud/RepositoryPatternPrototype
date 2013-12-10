using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.SqlServer;
using Microsoft.Practices.Unity;

namespace RepositoryPrototype
{
	public class UserMapper
	{
		private readonly IUserRepository _userRepository;

		[Dependency]
		protected IUserRepository ContextUserRepository { get; set; }

		public UserMapper()
		{
			DependencyResolver.Resolver.BuildUp(this);
			_userRepository = ContextUserRepository;
		}

		public IEnumerable<User> GetAllUsers()
		{
			return _userRepository.FindAll();
		}
	}
}