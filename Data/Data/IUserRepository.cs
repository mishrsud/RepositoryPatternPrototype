// -----------------------------------------------------------------------
// <copyright file="IUserRepository" company="SAXO BANK">
//     Saxo Bank A/S All Rights reserved 
// </copyright>
// <author>SMI</author>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Data
{
	/// <summary>
	/// Contract for the <see cref="User"/>
	/// </summary>
	public interface IUserRepository : IRepository<User, string>
	{
		/// <summary> Finds all Users. </summary>
		/// <returns></returns>
		IEnumerable<User> FindAll();

		/// <summary> Finds User by id. </summary>
		/// <param name="id">The id.</param>
		/// <returns></returns>
		IEnumerable<User> FindById(string id);
	}
}
