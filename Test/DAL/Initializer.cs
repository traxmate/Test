using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Models;

namespace Test.DAL
{
	public class Initializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductsContext>
	{
		public void ForceSeed()
		{
			Seed(ProductsContext.Create());
		}

		protected override void Seed(ProductsContext context)
		{
			var game = new Game();
			game.Name = "Pro Gamer Manager";
			game.Stores = new List<Store>
			{
				new Store { Name = "Steam" },
				new Store { Name = "Humble Bundle" },
				new Store { Name = "DRM-free" },
			};

			context.Stores.AddRange(game.Stores);
			context.SaveChanges();

			var gameBase = new Module();
			gameBase.Name = "Pro Gamer Manager";
			gameBase.Type = GameType.Original;
			gameBase.Platforms = new List<Platform>
			{
				new Platform { Name = "PC", OriginalPrice = 12.99m, },
				new Platform { Name = "Mac", OriginalPrice = 12.99m, },
				new Platform { Name = "Linux" },
			};

			context.Modules.Add(gameBase);
			context.SaveChanges();

			var gameDLC = new Module();
			gameDLC.Name = "Firefight Career DLC";
			gameDLC.Type = GameType.DLC;
			gameDLC.Platforms = new List<Platform>
			{
				new Platform { Name = "PC", OriginalPrice = 12.99m, },
				new Platform { Name = "Mac", OriginalPrice = 12.99m, },
				new Platform { Name = "Linux" },
			};

			context.Modules.Add(gameDLC);
			context.SaveChanges();

			game.Modules = new List<Module>
			{
				gameBase,
				gameDLC,
			};

			context.Games.Add(game);
			context.SaveChanges();
		}
	}
}