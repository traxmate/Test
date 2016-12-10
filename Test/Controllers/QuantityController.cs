using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Models;

namespace Test.Controllers
{
	public class QuantityController : Controller
	{
		[HttpPost]
		public ActionResult Calculate(int quantity, string moduleName, string platformName)
		{
			var repo = new GamesRepository();
			var module = repo.FindModule(moduleName);

			if(module != null)
			{
				var platform = module.Platforms.ToList().Find(a => a.Name == platformName);
				if(platform != null)
				{
					platform.Quantity = quantity;
					platform.CalculateTotal();

					repo.UpdateModule(module);
				}
			}

			return RedirectToAction("Index", "Home");
		}
	}
}