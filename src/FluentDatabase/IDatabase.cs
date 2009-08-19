using System;
using System.Collections.Generic;
using System.IO;

namespace FluentDatabase
{
	public interface IDatabase
	{
		string Name { get; set; }
		string Schema { get; set; }
		List<ITable> Tables { get; set; }

		IDatabase WithName( string name );
		IDatabase UsingSchema( string schema );
		IDatabase AddTable( Action<ITable> table );
		void Write( StreamWriter writer );
	}
}
