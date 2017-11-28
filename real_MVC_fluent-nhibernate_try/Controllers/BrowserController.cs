using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using real_MVC_fluent_nhibernate_try.Models;

namespace real_MVC_fluent_nhibernate_try.Controllers
{
    public class BrowserController : Controller
    {
        private ISession session = NHibernateHelper.OpenSession();
        // GET: Browser
        public ActionResult Index()
        {
            var stores = session.Query<Store>();
            return View(stores);
        }

        // GET: Browser/Type/1
        public ActionResult Type(int id)
        {
            var store = session.Get<Store>(id);
            return View(store);
        }

        // GET: Browser/Browse_Product?storename=Bargin%20Basin
        public ActionResult Browse_Product(string storename)
        {
            return View();
        }

        // GET: Browser/Details_Product/1
        public ActionResult Details_Product(int id)
        {
            var product = session.Get<Product>(id);
            return View(product);
        }

        // GET: Browser/Browse_Employee?storename=Bargin%20Basin
        public ActionResult Browse_Employee(string storename)
        {
            return View();
        }

        // GET: Browser/Details_Employee/1
        public ActionResult Details_Employee(int id)
        {
            var employee = session.Get<Employee>(id);
            return View(employee);
        }
    }
}