using System;
using System.Collections.Generic;
using System.IO;

namespace FluentDatabase
{
	public interface ITable
	{
		string Schema { get; set; }
		string Name { get; set; }
		List<IColumn> Columns { get; set; }

		ITable WithName( string name );
		ITable AddColumn( Action<IColumn> column );
		void Write( StreamWriter writer );
	}
}
