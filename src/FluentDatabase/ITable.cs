using System;

namespace FluentDatabase
{
	public interface ITable
	{
		ITable WithName( string name );
		ITable AddColumn( Action<IColumn> column );
	}
}
