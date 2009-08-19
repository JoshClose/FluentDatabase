using System;
using System.IO;

namespace FluentDatabase.MySql
{
	public class Database : DatabaseBase
	{
		protected override ITable CreateTable()
		{
			return new Table();
		}

		protected override void WriteUse( StreamWriter writer )
		{
			throw new NotImplementedException();
		}
	}
}
