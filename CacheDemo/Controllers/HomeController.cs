using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CacheDemo.Models;

namespace CacheDemo.Controllers
{
	public class HomeController : Controller
	{
		private readonly ReportService _reportService;

		public HomeController(ReportService reportService)
		{
			_reportService = reportService;
		}
		public ActionResult Index()
		{
			var productSaleAmounts = _reportService.GetProductSaleAmounts(1);
			ViewBag.Message = productSaleAmounts;
			return View("TestPage");
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

	}
}