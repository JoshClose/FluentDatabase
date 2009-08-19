using System;
using System.Collections.Generic;
using System.IO;

namespace FluentDatabase
{
	public abstract class DatabaseBase : IDatabase
	{
		public string Name { get; set; }
		public string Schema { get; set; }
		public List<ITable> Tables { get; set; }

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

		public IDatabase AddTable( Action<ITable> table )
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
				if( string.IsNullOrEmpty( table.Schema ) )
				{
					// If the schema has not been overriden at the schema level,
					// apply the database schema.
					table.Schema = Schema;
				}
				table.Write( writer );
				writer.WriteLine();
			}
		}
	}
}
