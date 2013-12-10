// -----------------------------------------------------------------------
// <copyright file="IRepository" company="SAXO BANK">
//     Saxo Bank A/S All Rights reserved 
// </copyright>
// <author>SMI</author>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	/// <summary>
	/// A generic Repository interface
	/// </summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TKey">The type of the key.</typeparam>
	public interface IRepository<TEntity, in TKey> where TEntity : class
	{
		TEntity Get(TKey id);
		TEntity GetAll();
	}
}
