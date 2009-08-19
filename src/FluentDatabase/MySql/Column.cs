using System;
using System.IO;

namespace FluentDatabase.MySql
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
