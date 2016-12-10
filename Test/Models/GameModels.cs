using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
	public enum GameType
	{
		Original,
		DLC,
	}

	public class Game
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Store> Stores { get; set; }
		public ICollection<Module> Modules { get; set; }
	}

	public class Module
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public GameType Type{ get; set; }
		public ICollection<Platform> Platforms { get; set; }
	}

	public class Platform
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal OriginalPrice { get; set; }
		public decimal SalePrice { get; set; }
		public int Quantity { get; set; }
		public decimal Total { get; set; }

		public void CalculateTotal()
		{
			decimal price = SalePrice != 0 ? SalePrice : OriginalPrice;
			Total = price * Quantity;
		}
	}

	public class Store
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}