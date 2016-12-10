using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.DAL;
using Test.Models;

namespace Test.Controllers
{
	public class HomeController : Controller
	{
		private ProductsContext db = new ProductsContext();

		public ActionResult Index()
		{
			var culture = new CultureInfo("en-US");
			ViewBag.Culture = culture;

			var model = new GamesRepository();
			return View(model);
		}
	}
}