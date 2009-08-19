#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Collections.Generic;
using System.IO;

namespace FluentDatabase
{
	public abstract class TableBase : ITable
	{
		public string Schema { get; set; }
		public string Name { get; set; }
		public List<IColumn> Columns { get; set; }

		protected abstract void WriteTableBegin( StreamWriter writer );
		protected abstract void WriteTableEnd( StreamWriter writer );

		protected TableBase()
		{
			Columns = new List<IColumn>();
		}

		public ITable WithName( string name )
		{
			Name = name;
			return this;
		}

		public ITable AddColumn( Action<IColumn> column )
		{
			var newColumn = CreateColumn();
			column.Invoke( newColumn );
			Columns.Add( newColumn );
			return this;
		}

		protected abstract IColumn CreateColumn();

		public void Write( StreamWriter writer )
		{
			WriteTableBegin( writer );
			foreach( var column in Columns )
			{
				column.Schema = Schema;
				column.Write( writer );
			}
			WriteTableEnd( writer );
		}
	}
}
