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
	/// <summary>
	/// Base class for creating a column. Use this instead
	/// of implementing <see cref="IColumn"/> directly.
	/// </summary>
	public abstract class ColumnBase : IColumn
	{
		protected string Schema { get; set; }
		protected string Name { get; set; }
		protected SqlDbType Type { get; set; }
		protected int Size { get; set; }
		protected bool AutoIncrementing { get; set; }
		protected List<IConstraint> Constraints { get; set; }

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

		public IColumn UsingSchema( string schema )
		{
			Schema = schema;
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

        public IColumn HasConstraint( Action<IConstraint> constraint )
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
				constraint.UsingSchema( Schema );
				constraint.Write( writer );
			}
			WriteColumnEnd( writer );
		}
	}
}
