#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
using System;

namespace FluentDatabase
{
	/// <summary>
	/// Represents errors that occur when using FluentDatabase.
	/// </summary>
	public class FluentDatabaseException : Exception
	{
		/// <summary>
		/// Creates a new instance of FluentDatabaseException.
		/// </summary>
		/// <param name="message">The error message.</param>
		public FluentDatabaseException( string message ) : base( message ){}
	}
}
