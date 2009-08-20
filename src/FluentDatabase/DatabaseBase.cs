#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Collections.Generic;
using System.IO;

namespace FluentDatabase
{
	/// <summary>
	/// Base class for creating a database. Use this instead
	/// of implementing <see cref="IDatabase"/> directly.
	/// </summary>
	public abstract class DatabaseBase : IDatabase
	{
		protected string Name { get; set; }
		protected string Schema { get; set; }
		protected List<ITable> Tables { get; set; }

		protected abstract ITable CreateTable();
		protected abstract void WriteUse( StreamWriter writer );

		protected DatabaseBase()
		{
			Tables = new List<ITable>();
			Schema = "dbo";
		}

		public IDatabase WithName( string name )
		{
			Name = name;
			return this;
		}

		public IDatabase UsingSchema( string schema )
		{
			Schema = schema;
			return this;
		}

		public IDatabase HasTable( Action<ITable> table )
		{
			var newTable = CreateTable();
			table.Invoke( newTable );
			Tables.Add( newTable );
			return this;
		}

		public void Write( StreamWriter writer )
		{
			WriteUse( writer );
			writer.WriteLine();
			foreach( var table in Tables )
			{
				table.UsingSchema( Schema );
				table.Write( writer );
				writer.WriteLine();
			}
		}
	}
}
