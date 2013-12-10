using System;

namespace Data.SqlServer
{
	public abstract class RepositoryBase
	{
		/// <summary>
		/// Gets the db context.
		/// </summary>
		/// <value>
		/// The db context.
		/// </value>
		internal IDbContext DbContext { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="RepositoryBase"/> class.
		/// </summary>
		/// <param name="dbContext">The db context.</param>
		/// <exception cref="System.ArgumentNullException">dbContext</exception>
		protected RepositoryBase(IDbContext dbContext)
		{
			if (dbContext == null)
			{
				throw new ArgumentNullException("dbContext");
			}

			DbContext = dbContext;
		}

		/// <summary>
		/// Casts the specified column value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="columnValue">The column value.</param>
		/// <returns></returns>
		public T Cast<T>(object columnValue)
		{
			if (columnValue is DBNull || columnValue == null)
			{
				return default(T);
			}

			return (T)Convert.ChangeType(columnValue, typeof(T));
		}
	}
}
