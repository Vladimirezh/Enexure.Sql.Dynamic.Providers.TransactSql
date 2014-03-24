﻿using System;
using System.Text;
using System.Collections.Generic;
using Enexure.Sql.Dynamic.Providers.TransactSql;
using Enexure.Sql.Dynamic.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Enexure.Sql.Dynamic.Providers;

namespace Enexure.Sql.Dynamic.Tests
{
	/// <summary>
	/// Summary description for DerivedTablesTest
	/// </summary>
	[TestClass]
	public class AggregateTest
	{
		[TestMethod]
		public void Count()
		{
			var table = new Table("Table");

			var query = Query
				.From(table)
				.Select(table.Field("Name").Count().AsSelf());

			var sql = Provider.GetSqlString(query);

			var expected =
				"select count([Table].[Name])" + Environment.NewLine +
				"from [Table]";

			Assert.AreEqual(expected, sql);
		}

		[TestMethod]
		public void Sum()
		{
			var table = new Table("Table");

			var query = Query
				.From(table)
				.Select(table.Field("Name").Sum().AsSelf());

			var sql = Provider.GetSqlString(query);

			var expected =
				"select sum([Table].[Name])" + Environment.NewLine +
				"from [Table]";

			Assert.AreEqual(expected, sql);
		}
	}
}
