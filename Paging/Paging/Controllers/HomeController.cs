using Paging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Paging.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int? page)
        {
            var dummyItems = Enumerable.Range(1, 150).Select(x => "Item " + x);
            var pager = new Pager(dummyItems.Count(), page);

            var viewModel = new Customer
            {
                Items = dummyItems.Skip((pager.CurrentPage - 1) * pager.PageSize).Take(pager.PageSize),
                Pager = pager
            };

            return View(viewModel);
        }




        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}