using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeMS.Models;

namespace EmployeeMS.Controllers
{
    public class DepartmentsController : Controller
    {
        Departments department = new Departments();
        // GET: Departments
        public ActionResult Index()
        {
            var list = department.GetAllRecordDept();
            return View(list);
        }

        public ActionResult InsertRecordDept()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertRecordDept(Departments dept)
        {
            if (ModelState.IsValid)
            {
                dept.InsertDept(dept);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var item = department.Find(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Departments dept)
        {
            if (ModelState.IsValid)
            {
                department.Update(dept);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            var item = department.Find(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(Departments dept)
        {
            if (ModelState.IsValid)
            {
                department.DeleteDept(dept);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}