using System;
using System.IO;

namespace FluentDatabase.Sqlite
{
	public class Column : ColumnBase
	{
		protected override void WriteColumnBegin( StreamWriter writer )
		{
			throw new NotImplementedException();
		}

		protected override void WriteColumnEnd( StreamWriter writer )
		{
			throw new NotImplementedException();
		}

		protected override IConstraint CreateConstraint()
		{
			return new Constraint();
		}
	}
}
