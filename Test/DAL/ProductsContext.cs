using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.DAL
{
	public class ProductsContext : DbContext
	{
		public ProductsContext() : base("name=DefaultConnection")
		{

		}

		public static ProductsContext Create()
		{
			return new ProductsContext();
		}

		/* Function that tries to save changes to the database and returns any error if fail.
		*/
		public static string TrySaveChanges(ProductsContext db)
		{
			string message = "";

			try
			{
				db.SaveChanges();
			}
			catch (DbEntityValidationException e)
			{
				foreach (var item in e.EntityValidationErrors)
				{
					foreach (var error in item.ValidationErrors)
					{
						message += error.PropertyName + ": " + error.ErrorMessage;
					}
				}
			}

			return message;
		}

		public DbSet<Game> Games { get; set; }
		public DbSet<Store> Stores { get; set; }
		public DbSet<Module> Modules { get; set; }
	}
}