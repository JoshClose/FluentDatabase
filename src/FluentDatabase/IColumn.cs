using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace FluentDatabase
{
	public interface IColumn
	{
		string Schema { get; set; }
		string Name { get; set; }
		SqlDbType Type { get; set; }
		int Size { get; set; }
		bool AutoIncrementing { get; set; }
		List<IConstraint> Constraints { get; set; }

		IColumn WithName( string name );
		IColumn OfType( SqlDbType type );
		IColumn WithSize( int size );
		IColumn IsAutoIncrementing();
		IColumn AddConstraint( Action<IConstraint> constraint );
		void Write( StreamWriter writer );
	}
}
