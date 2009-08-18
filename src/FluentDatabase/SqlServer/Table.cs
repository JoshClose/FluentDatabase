namespace FluentDatabase.SqlServer
{
	public class Table : TableBase
	{
		protected override IColumn CreateColumn()
		{
			return new Column();
		}
	}
}
