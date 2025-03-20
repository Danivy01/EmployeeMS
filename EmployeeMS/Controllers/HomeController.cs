using EmployeeMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMS.Controllers
{
    public class HomeController : Controller
    {
        Employees employees = new Employees();
        public ActionResult Index()
        {

            var list = employees.GetAllEmp();
            return View(list);
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

        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employees emp)
        {
            if (ModelState.IsValid)
            {
                emp.CreateEmployee(emp);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var item = employees.Find(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Employees emp)
        {
            if (ModelState.IsValid)
            {
                emp.UpdateEmployee(emp);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            var item = employees.Find(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(Employees emp)
        {
            if (ModelState.IsValid)
            {
                employees.DeleteEmp(emp);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Details(int Id)
        {
            var item = employees.Find(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Details(Employees emp)
        {
            if (ModelState.IsValid)
            {
                employees.Details(emp);
                return RedirectToAction("Index");
            }
            return View();
        }
    }

}