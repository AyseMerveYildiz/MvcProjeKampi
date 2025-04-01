using DataaAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context context= new Context();
        public ActionResult Index()
        {
            var categoryCount = context.Categories.Count();
            ViewBag.categoryCount = categoryCount;

            var swHeadingCount = context.Headings.Count(x => x.CategoryID == context.Categories.Where(y => y.CategoryName == "Yazılım").Select(c => c.CategoryID).FirstOrDefault());
            ViewBag.swHeadingCount = swHeadingCount;

            var writerCount = context.Writers.Count(x => x.WriterName.Contains("a"));
            ViewBag.writerCount = writerCount;

            var maxHeadingCategory = context.Categories.Join(context.Headings, x => x.CategoryID, y => y.CategoryID, (x, y) => x).GroupBy(x => x.CategoryName).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
            ViewBag.maxHeadingCategory = maxHeadingCategory;

            var categoryStatus = (context.Categories.Where(x => x.CategoryStatus == true).Count() - context.Categories.Where(x => x.CategoryStatus == false).Count());
            ViewBag.categoryStatus = categoryStatus;

            return View();
        }
    }
}