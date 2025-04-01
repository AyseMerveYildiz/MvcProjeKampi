using BusinessLayer.Concrete;
using DataaAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm= new HeadingManager(new EFHeadingDal());
        CategoryManager cm= new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();
            ViewBag.vlc = valueCategory;

            List<SelectListItem> valueWriter = (from x in wm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.WriterName + " " + x.WriterSurname,
                                                      Value = x.WriterID.ToString()
                                                  }).ToList();
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ContentByHeading(int id)
        {
            return View();
        }
    }
}