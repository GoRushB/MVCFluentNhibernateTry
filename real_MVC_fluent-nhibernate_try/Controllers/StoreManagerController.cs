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
    public class StoreManagerController : Controller
    {
        private ISession session = NHibernateHelper.OpenSession();
        // GET: StoreManager
        public ActionResult Index()
        {
            var stores = session.Query<Store>();
            return View(stores);
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: StoreManager/Create
        [HttpPost]
        public ActionResult Create(Store store)
        {
            try
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(store);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: StoreManager/Edit/1
        public ActionResult Edit(int id)
        {
            var store = session.Get<Store>(id);
            return View(store);
        }

        // POST: StoreManager/Edit/1
        [HttpPost]
        public ActionResult Edit(int id, Store store)
        {
            try
            {
                var storetoUpdate = session.Get<Store>(id);
                storetoUpdate.Name = store.Name;
                storetoUpdate.StoreArtUrl = store.StoreArtUrl;
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(storetoUpdate);
                    transaction.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreManager/Details/1
        public ActionResult Details(int id)
        {
            var store = session.Get<Store>(id);
            return View(store);
        }

        // GET: StoreManager/Delete/1
        public ActionResult Delete(int id)
        {
            var store = session.Get<Store>(id);
            return View(store);
        }

        // POST: StoreManager/Delete/1
        [HttpPost]
        public ActionResult Delete(int id, Store store)
        {
            try
            {
                var store_ = session.Get<Store>(id);
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(store_);
                    transaction.Commit();
                }

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }
    }
}