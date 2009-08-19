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
	public interface IDatabase
	{
		string Name { get; set; }
		string Schema { get; set; }
		List<ITable> Tables { get; set; }

		IDatabase WithName( string name );
		IDatabase UsingSchema( string schema );
		IDatabase AddTable( Action<ITable> table );
		void Write( StreamWriter writer );
	}
}
