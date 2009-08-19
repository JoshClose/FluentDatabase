#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace FluentDatabase
{
	public abstract class ColumnBase : IColumn
	{
		public string Schema { get; set; }
		public string Name { get; set; }
		public SqlDbType Type { get; set; }
		public int Size { get; set; }
		public bool AutoIncrementing { get; set; }
		public List<IConstraint> Constraints { get; set; }

		protected abstract void WriteColumnBegin( StreamWriter writer );
		protected abstract void WriteColumnEnd( StreamWriter writer );

		protected ColumnBase()
		{
			Constraints = new List<IConstraint>();
		}

		public IColumn WithName( string name )
		{
			Name = name;
			return this;
		}

		public IColumn OfType( SqlDbType type )
		{
			Type = type;
			return this;
		}

		public IColumn OfType( SqlDbType type, int size )
		{
			Size = size;
			OfType( type );
			return this;
		}

		public IColumn IsAutoIncrementing()
		{
			AutoIncrementing = true;
			return this;
		}

        public IColumn AddConstraint( Action<IConstraint> constraint )
        {
        	var newConstraint = CreateConstraint();
        	constraint.Invoke( newConstraint );
        	Constraints.Add( newConstraint );
			return this;
        }

		protected abstract IConstraint CreateConstraint();

		public void Write( StreamWriter writer )
		{
			WriteColumnBegin( writer );
			foreach( var constraint in Constraints )
			{
				constraint.Schema = Schema;
				constraint.Write( writer );
			}
			WriteColumnEnd( writer );
		}
	}
}
