using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Курсовик.Models;
using Курсовик.DAO;

namespace Курсовик.Controllers
{
    public class КатегорияController : Controller
    {
        КатегорияDAO КатегорияDAO = new КатегорияDAO();
        // GET: Категория
        public ActionResult Index()
        {
            return View(КатегорияDAO.Список_категорий());
        }

        // GET: Категория/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Категория/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Категория/Create
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

        // GET: Категория/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Категория/Edit/5
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

        // GET: Категория/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Категория/Delete/5
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
