using System;

namespace FluentDatabase
{
	public interface IDatabase
	{
		IDatabase WithName( string name );
		IDatabase UseSchema( string schema );
		IDatabase AddTable( Action<ITable> table );
	}
}
