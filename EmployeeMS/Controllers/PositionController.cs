using EmployeeMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeMS.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        Positions mod = new Positions();
        public ActionResult Index()
        {
            var list = mod.GetAllRecords();
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

        public ActionResult InsertRecord()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InsertRecord(Positions pos)
        {
            if (ModelState.IsValid)
            {
                mod.InsertRecord(pos);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int Id)
        {
            var item = mod.FindRecord(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(Positions pos)
        {
            if (ModelState.IsValid)
            {
                mod.UpdateRecord(pos);
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeleteRecord(int Id)
        {
            var item = mod.FindRecord(Id);
            return View(item);
        }

        [HttpPost]
        public ActionResult DeleteRecord(Positions pos)
        {
            if (ModelState.IsValid)
            {
                mod.DeleteRecord(pos);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}