namespace FluentDatabase.SqlServer
{
	public class Database : DatabaseBase
	{
		protected override ITable CreateTable()
		{
			return new Table();
		}
	}
}
