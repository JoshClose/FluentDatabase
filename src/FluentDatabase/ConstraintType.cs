#region License
// Copyright 2009 Josh Close
// This file is a part of FluentDatabase and is licensed under the MS-PL
// See LICENSE.txt for details or visit http://www.opensource.org/licenses/ms-pl.html
#endregion
namespace FluentDatabase
{
	public enum ConstraintType
	{
		PrimaryKey = 1,
		ForeignKey = 2,
		Unique = 3,
		Check = 4,
		NotNull
	}
}
