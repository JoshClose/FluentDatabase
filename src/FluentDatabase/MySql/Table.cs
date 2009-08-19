using System;
using System.IO;

namespace FluentDatabase.MySql
{
	public class Table : TableBase
	{
		protected override void WriteTableBegin( StreamWriter writer )
		{
		}

		protected override void WriteTableEnd( StreamWriter writer )
		{
		}

		protected override IColumn CreateColumn()
		{
			return new Column();
		}
	}
}
