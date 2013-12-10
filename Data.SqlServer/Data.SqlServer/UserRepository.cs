using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Practices.Unity;

namespace Data.SqlServer
{
	public class UserRepository : RepositoryBase, IUserRepository
	{
		private readonly string _connectionStrings = ConfigurationManager.ConnectionStrings["UserDb"].ConnectionString;

		/// <summary>
		/// Initializes a new instance of the <see cref="UserRepository"/> class.
		/// </summary>
		/// <param name="dbContext">The db context.</param>
		public UserRepository(IDbContext dbContext)
			: base(dbContext) { }

		public IEnumerable<User> FindAll()
		{
			var result = new List<User>();

			using (var command = DbContext.CreateCommand(_connectionStrings, "dbo.GetAllUsers"))
			{
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(new User
							{
								Id = Cast<int>(reader["Id"]),
								FirstName = Cast<string>(reader["FirstName"]),
								LastName = Cast<string>(reader["LastName"]),
								DateOfBirth = Cast<DateTime>(reader["DateOfBirth"]),
								Email = Cast<string>(reader["Email"])
							}
						);
					}
				}
			}

			return result;
		}

		public IEnumerable<User> FindById(string id)
		{
			var result = new List<User>();

			using (var command = DbContext.CreateCommand(_connectionStrings, "dbo.GetUserById"))
			{
				command.Parameters.Add(new SqlParameter("Id", id));

				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						result.Add(new User
							{
								Id = Cast<int>(reader["Id"]),
								FirstName = Cast<string>(reader["FirstName"]),
								LastName = Cast<string>(reader["LastName"]),
								DateOfBirth = Cast<DateTime>(reader["LastName"]),
								Email = Cast<string>(reader["Email"])
							}
						);
					}
				}
			}

			return result;
		}

		public User Get(string id)
		{
			throw new NotImplementedException();
		}

		public User GetAll()
		{
			throw new NotImplementedException();
		}
	}
}