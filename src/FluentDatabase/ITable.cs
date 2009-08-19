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
	public interface ITable
	{
		string Schema { get; set; }
		string Name { get; set; }
		List<IColumn> Columns { get; set; }

		ITable WithName( string name );
		ITable AddColumn( Action<IColumn> column );
		void Write( StreamWriter writer );
	}
}
