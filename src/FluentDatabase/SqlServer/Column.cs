namespace FluentDatabase.SqlServer
{
	public class Column : ColumnBase
	{
		protected override IConstraint CreateConstraint()
		{
			return new Constraint();
		}
	}
}
