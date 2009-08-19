using System;
using System.IO;

namespace FluentDatabase.Oracle
{
	public class Column : ColumnBase
	{
		protected override void WriteColumnBegin( StreamWriter writer )
		{
		}

		protected override void WriteColumnEnd( StreamWriter writer )
		{
		}

		protected override IConstraint CreateConstraint()
		{
			return new Constraint();
		}
	}
}