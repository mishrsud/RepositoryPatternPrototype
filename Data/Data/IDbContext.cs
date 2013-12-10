// -----------------------------------------------------------------------
// <copyright file="IDbContext" company="SAXO BANK">
//     Saxo Bank A/S All Rights reserved 
// </copyright>
// <author>SMI</author>
// -----------------------------------------------------------------------

using System;
using System.Data;

namespace Data
{
	/// <summary>
	/// 
	/// </summary>
	public interface IDbContext : IDisposable
	{
		/// <summary>
		/// This method returns new instance of command with same instance of connection on source type
		/// This might create problem in parallel execution of multiple data readers with same instance of db connection
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="args">The args.</param>
		/// <returns></returns>
		IDbCommand CreateCommand(string connectionString, string commandText = "", params IDbDataParameter[] args);

		/// <summary>
		/// This method returns new instance of command with same instance of connection on source type
		/// This might create problem in parallel execution of multiple data readers with same instance of db connection
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		/// <param name="commandTimeOut">The command time out.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="args">The args.</param>
		/// <returns></returns>
		IDbCommand CreateCommand(string connectionString, int commandTimeOut, string commandText = "", params IDbDataParameter[] args);

		/// <summary>
		/// This method will return new instance of command with new instance of connection
		/// It is useful in case of multiple threads executing data reader and db commands
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="args">The args.</param>
		/// <returns></returns>
		IDbCommand CreateNewCommand(string connectionString, string commandText = "", params IDbDataParameter[] args);

		/// <summary>
		/// This method will return new instance of command with new instance of connection
		/// It is useful in case of multiple threads executing data reader and db commands
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		/// <param name="commandTimeOut">The command time out.</param>
		/// <param name="commandText">The command text.</param>
		/// <param name="args">The args.</param>
		/// <returns></returns>
		IDbCommand CreateNewCommand(string connectionString, int commandTimeOut, string commandText = "", params IDbDataParameter[] args);
	}
}
