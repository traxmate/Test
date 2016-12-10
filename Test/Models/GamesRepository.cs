using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using Test.DAL;

namespace Test.Models
{
	public class GamesRepository
	{
		private ProductsContext db = new ProductsContext();

		~GamesRepository()
		{
			if(db != null)
			{
				db.Dispose();
			}
		}

		public Game FindGame(string name)
		{
			return db.Games.ToList().Find(a => a.Name == name);
		}

		public IEnumerable<Game> GetAllGames()
		{
			return db.Games.Include(n => n.Modules).Include(n => n.Stores).Include(n => n.Modules.Select(c => c.Platforms)).ToArray();
		}

		public Store FindStore(string name)
		{
			return db.Stores.ToList().Find(a => a.Name == name);
		}

		public IEnumerable<Store> GetAllStores()
		{
			return db.Stores.ToArray();
		}

		public Module FindModule(string name)
		{
			return db.Modules.Include(a => a.Platforms).ToList().Find(a => a.Name == name);
		}

		public void UpdateModule(Module module)
		{
			db.Entry(module).State = EntityState.Modified;
			db.SaveChanges();
		}

		public IEnumerable<Module> GetAllModules()
		{
			return db.Modules.ToArray();
		}
	}
}