using System.IO;

namespace FluentDatabase.Sqlite
{
	public class Database : DatabaseBase
	{
		protected override ITable CreateTable()
		{
			return new Table();
		}

		protected override void WriteUse( StreamWriter writer )
		{
			// SQLite is a single database and doesn't have the USE statement.
		}
	}
}
