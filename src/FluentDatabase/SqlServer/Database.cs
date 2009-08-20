#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System.IO;

namespace FluentDatabase.SqlServer
{
	/// <summary>
	/// SQL Server database.
	/// </summary>
	public class Database : DatabaseBase
	{
		protected override ITable CreateTable()
		{
			return new Table();
		}

		protected override void WriteUse( StreamWriter writer )
		{
			if( !string.IsNullOrEmpty( Name ) )
			{
				writer.WriteLine( string.Format( "USE [{0}]", Name ) );
			}
		}
	}
}
