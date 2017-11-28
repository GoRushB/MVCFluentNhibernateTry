using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using real_MVC_fluent_nhibernate_try.Models;

namespace real_MVC_fluent_nhibernate_try.Controllers
{
    public class EmployeeManagerController : Controller
    {
        private ISession session = NHibernateHelper.OpenSession();
        // GET: EmployeeManager/1
        public ActionResult Index(int storeid)
        {
            ViewBag.storeid = storeid;
            var employees = session.Get<Store>(storeid).Employees;
            return View(employees);
        }

        // GET: EmployeeManager/Details/5
        public ActionResult Details(int id)
        {
            var employee = session.Get<Employee>(id);
            return View(employee);
        }

        // GET: EmployeeManager/Create/1
        public ActionResult Create(int storeid)
        {
            ViewBag.storeid = storeid;
            return View();
        }

        // POST: EmployeeManager/Create
        [HttpPost]
        public ActionResult Create(int storeid, Employee employee)
        {
            try
            {
                var store = session.Get<Store>(storeid);
                store.AddEmployee(employee);
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(employee);
                    transaction.Commit();
                }
                return RedirectToAction("Index", new {storeid = employee.Store.StoreId});
            }
            catch(Exception exception)
            {
                return View();
            }
        }

        // GET: EmployeeManager/Edit/5
        public ActionResult Edit(int id)
        {
            var employee = session.Get<Employee>(id);
            return View(employee);
        }

        // POST: EmployeeManager/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                var employeetoUpdate = session.Get<Employee>(id);
                employeetoUpdate.Name = employee.Name;
                employeetoUpdate.EmployeeArtUrl = employee.EmployeeArtUrl;

                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(employeetoUpdate);
                    transaction.Commit();
                }
                return RedirectToAction("Index", new {storeid = employeetoUpdate.Store.StoreId});
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeManager/Delete/5
        public ActionResult Delete(int id)
        {
            var employee = session.Get<Employee>(id);
            return View(employee);
        }

        // POST: EmployeeManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                var employee_ = session.Get<Employee>(id);
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(employee_);
                    transaction.Commit();
                }

                return RedirectToAction("Index", new {storeid = employee_.Store.StoreId});
            }
            catch(Exception exception)
            {
                return View();
            }
        }
    }
}
