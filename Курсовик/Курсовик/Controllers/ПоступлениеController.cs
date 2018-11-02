using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.Models;
using Курсовик.DAO;

namespace Курсовик.Controllers
{
    public class ПоступлениеController : Controller
    {
        ПродукцияDAO ПродукцияDAO = new ПродукцияDAO();
        // GET: Поступление
        public ActionResult Index()
        {
            return View();
        }

        // GET: Поступление/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Поступление/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Поступление/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Поступление/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Поступление/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Поступление/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Поступление/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
