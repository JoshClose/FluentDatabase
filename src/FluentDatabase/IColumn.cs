using System;
using System.Data;

namespace FluentDatabase
{
	public interface IColumn
	{
		IColumn WithName( string name );
		IColumn OfType( SqlDbType type );
		IColumn IsAutoIncrementing();
		IColumn AddConstraint( Action<IConstraint> constraint );
	}
}
