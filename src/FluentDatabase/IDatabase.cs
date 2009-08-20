#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.IO;

namespace FluentDatabase
{
	/// <summary>
	/// Template for creating a database.
	/// </summary>
	public interface IDatabase
	{
		/// <summary>
		/// Sets the name of the database.
		/// </summary>
		/// <param name="name">The name of the database to use.</param>
		IDatabase WithName( string name );

		/// <summary>
		/// Sets the schema of the database.
		/// </summary>
		/// <param name="schema">The name of the schema to use.</param>
		IDatabase UsingSchema( string schema );

		/// <summary>
		/// Adds a table to the database.
		/// </summary>
		/// <param name="table">The added table.</param>
		IDatabase HasTable( Action<ITable> table );

		/// <summary>
		/// Writes the database and all subsequent children to writer.
		/// </summary>
		/// <param name="writer">The writer.</param>
		void Write( StreamWriter writer );
	}
}
