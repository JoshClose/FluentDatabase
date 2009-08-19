using System.IO;

namespace FluentDatabase.SqlServer
{
	public class Table : TableBase
	{
		protected override IColumn CreateColumn()
		{
			return new Column();
		}

		protected override void WriteTableBegin( StreamWriter writer )
		{
			writer.WriteLine( string.Format( "CREATE TABLE [{0}].[{1}]", Schema, Name ) );
			writer.WriteLine( "(" );
		}

		protected override void WriteTableEnd( StreamWriter writer )
		{
			writer.WriteLine( ")" );
		}
	}
}
