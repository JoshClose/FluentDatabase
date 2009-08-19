using System.IO;

namespace FluentDatabase.SqlServer
{
	public class Database : DatabaseBase
	{
		protected override ITable CreateTable()
		{
			return new Table();
		}

		protected override void WriteUse( StreamWriter writer )
		{
			writer.WriteLine( string.Format( "USE [{0}]", Name ) );
		}
	}
}
